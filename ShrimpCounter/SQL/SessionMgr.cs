using ShrimpCounter.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;


namespace ShrimpCounter.SQL
{
    public class Session
    {
        [DisplayName("ID")]
        public string id { get; set; }    
        [DisplayName("Thời gian chụp")]
        public DateTime timeCreate { get; set; }        
        [Browsable(false)]
        public string imagePath { get; set; }
        public int total { get; set; }
        [Browsable (false)]
        public string result { get; set; }

        [Browsable(false)]
        public bool isDeleted { get; set; }
        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Session()
        {
            timeCreate = DateTime.Now;
            isDeleted = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Session(DataRow row)
        {
            id = row["id"].ToString();
            timeCreate = DateTime.Parse( row["timeCreate"].ToString() );
            result = row["result"].ToString();
            imagePath = row["imagePath"].ToString();
            total = int.Parse(row["total"].ToString());
            isDeleted = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Insert()
        {
            string sql = string.Format("INSERT INTO Session(imagePath, total, result, timeCreate) " +
                "VALUES('{0}','{1}','{2}','{3}')",
                imagePath,
                total,
                result,
                timeCreate.ToString("yyyy-MM-dd HH:mm:ss"));


            return TGMTsqlite.GetInstance().ExecuteNonQuery(sql) > 0;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Update()
        {
            string sql = string.Format("UPDATE Session set " +
                "imagePath='{0}'," +
                "total='{1}'," +
                "result='{2}', " +
                "timeCreate='{3}', ",
                imagePath,
                total,
                result,
                timeCreate.ToString("yyyy-MM-dd HH:mm:ss"));


            return TGMTsqlite.GetInstance().ExecuteNonQuery(sql) > 0;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataGridViewRow ToDataGridViewRow(bool showImage)
        {
            DataGridViewRow row = new DataGridViewRow();

            // Create and add the cells to the row
            row.Cells.Add(new DataGridViewTextBoxCell { Value = id });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = timeCreate.ToString("HH:mm:ss dd/MM/yyyy") });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = total });

            if (showImage)
            {
                if (imagePath != null && File.Exists(imagePath))
                {
                    Image img = Image.FromFile(imagePath);
                    if (img != null && img.Width != 0 && img.Height != 0)
                    {
                        img = TGMTimage.ResizeImageByWidth(img, 200);
                        row.Cells.Add(new DataGridViewImageCell { Value = img });
                    }
                }
            }

            return row;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string[] ToArray(int index, bool fullPath = true)
        {
            string[] arr = new string[7];
            arr[0] = index.ToString();
            arr[1] = fullPath ? imagePath : Path.GetFileName(imagePath); 
            arr[2] = total.ToString();
            arr[3] = result;
            arr[3] = timeCreate.ToString("HH:mm:ss dd/MM/yyyy");
            return arr;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SessionMgr
    {
        public static List<Session> Sessions;

        public static bool LoadSessions(DateTime fromDate, DateTime toDate, string plate = "", float score=0.0f)
        {
            Sessions = new List<Session>();
            string sql = string.Format("select * from Session where isDeleted='0'");

            if(fromDate != null && fromDate.Year > 1)
            {
                sql += string.Format(" and timeCreate>= '{0}'", fromDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (toDate != null && toDate.Year > 1)
            {
                sql += string.Format(" and timeCreate<= '{0}'", toDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            //if(score > 0.0f)
            //{
            //    sql += " and Score>=" + score.ToString();
            //}

            //if (plate != "")
            //{
            //    plate = plate.ToLower();
            //    sql += string.Format(" and Alphanumeric like '%{0}%'", plate);
            //}
                

            DataSet ds = TGMTsqlite.GetInstance().LoadData(sql);
            if (ds == null)
                return false;

            DataTable tbl = ds.Tables[0];
            if (tbl.Rows.Count == 0)
                return false;



            foreach (DataRow row in tbl.Rows)
            {
                Session session = new Session(row);
                Sessions.Add(session);
            }

            return Sessions.Count > 0;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int CountInParkingSession()
        {
            Sessions = new List<Session>();
            string sql = string.Format("select * from Session where IsDeleted=0 and Status='Trong bãi'");

            DataSet ds = TGMTsqlite.GetInstance().LoadData(sql);
            if (ds == null)
                return 0;

            DataTable tbl = ds.Tables[0];
            return tbl.Rows.Count;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //public static Session QueryByCard(string cardID)
        //{
        //    //Cards = new List<Card>();

        //    string sql = string.Format("select * from Session where IsDeleted='0' and Status='{1}' and CardID='{2}'", false, "Trong bãi", cardID);
        //    DataSet ds = TGMTsqlite.GetInstance().LoadData(sql);
        //    if (ds == null)
        //        return null;

        //    DataTable tbl = ds.Tables[0];
        //    if (tbl.Rows.Count == 0)
        //        return null;
        //    else if(tbl.Rows.Count > 1)
        //    {
        //        MsgBox.Show("Tìm thấy 2 lượt xe đang dùng thẻ " + cardID);
        //        return null;
        //    }

        //    DataRow row = tbl.Rows[0];
        //    Session session = new Session
        //    {
        //        id = row["id"].ToString(),
        //        Text = row["Text"].ToString(),
        //        Alphanumeric = row["Alphanumeric"].ToString(),
        //        CheckinTime = DateTime.Parse(row["CheckinTime"].ToString()),
        //        ImagePath = row["ImagePath"].ToString(),
        //    };

        //    return new Session(row);
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Session FindByPlate(string plate)
        {
            if (plate == "")
                return null;

            string alphanumeric = TGMTutil.ConvertToAlphanumeric(plate);
            string sql = string.Format("select * from Session where IsDeleted='0' and AlphanumericIn='{0}' and Status='{1}'",
                alphanumeric, "Trong bãi");
            DataSet ds = TGMTsqlite.GetInstance().LoadData(sql);
            if (ds == null)
                return null;

            DataTable tbl = ds.Tables[0];
            if (tbl.Rows.Count == 0)
                return null;
            else if (tbl.Rows.Count > 1)
            {
                MsgBox.Show("Tìm thấy 2 lượt xe trong bãi có cùng biển số: " + plate);
                return null;
            }

            DataRow row = tbl.Rows[0];
            
            return new Session(row);
        }

        
    }
}
