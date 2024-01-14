using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DeThiCuoiKy.Models
{
    public class DataContext : DbContext
    {
        public string ConnectString { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectString);
        }

        public int sqlInsertDCL(DIEMCACHLY dcl)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=clcovid;";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "INSERT INTO DIEMCACHLY VALUES (@MADIEMCACHLY,@TENDIEMCACHLY,@DIACHI);";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MADIEMCACHLY", dcl.MaDiemCachLy);
                cmd.Parameters.AddWithValue("TENDIEMCACHLY", dcl.TenDiemCachLy);
                cmd.Parameters.AddWithValue("DIACHI", dcl.DiaChi);
                return cmd.ExecuteNonQuery();

            }
        }

        public List<object> getListCongNhan(int soluong)
        {
            List<object> list = new List<object>();
            string connection = "server=localhost;user id=root;password=;port=3306;database=clcovid;";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "SELECT c.TenCongNhan,c.NamSinh,c.NuocVe,Count(ct.MaTrieuChung)  as 'SOLUONG' FROM CONGNHAN c JOIN CN_TC ct ON c.MaCongNhan= ct.MaCongNhan GROUP BY c.TenCongNhan,c.NamSinh,c.NuocVe HAVING Count(ct.MaTrieuChung) >=  @SOLUONG";

                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("SOLUONG", soluong);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            tencn = reader["TenCongNhan"].ToString(),
                            namsinh = Convert.ToInt32(reader["NamSinh"].ToString()),
                            nuocve = reader["NuocVe"],
                            sl = Convert.ToInt32(reader["SOLUONG"].ToString()),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                return list;
            }
        }

        public List<DIEMCACHLY> getListTenDiemCachLy()
        {
            List<DIEMCACHLY> list = new List<DIEMCACHLY>();
            string connection = "server=localhost;user id=root;password=;port=3306;database=clcovid;";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "SELECT MADIEMCACHLY,TENDIEMCACHLY,DIACHI FROM DIEMCACHLY;";

                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DIEMCACHLY dcl = new(reader["MADIEMCACHLY"].ToString(), reader["TENDIEMCACHLY"].ToString(), reader["DIACHI"].ToString());
                        list.Add(dcl);
                    }
                    reader.Close();
                }
                return list;
            }
        }

        public List<CONGNHAN> getListCNCL(string maDCL)
        {
            List<CONGNHAN> list = new List<CONGNHAN>();
            string connection = "server=localhost;user id=root;password=;port=3306;database=clcovid;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "SELECT MACONGNHAN,TENCONGNHAN FROM CONGNHAN WHERE MADIEMCACHLY=@dcl;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@dcl", maDCL);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        {
                            list.Add(new CONGNHAN()
                            {
                                MaCongNhan = reader["MACONGNHAN"].ToString(),
                                TenCongNhan = reader["TENCONGNHAN"].ToString()
                            });
                        }
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public int DeleteCN(string maCN)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=clcovid;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "DELETE FROM CONGNHAN WHERE MACONGNHAN=@maCN;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@maCN", maCN);
                return cmd.ExecuteNonQuery();
            }
        }

        public CONGNHAN ViewCN(string maCN)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=clcovid;";
            CONGNHAN cn = new CONGNHAN();
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "SELECT * FROM CONGNHAN WHERE MACONGNHAN=@maCN;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@maCN", maCN);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    cn.MaCongNhan = reader["MACONGNHAN"].ToString();
                    cn.TenCongNhan = reader["TENCONGNHAN"].ToString();
                    cn.GioiTinh = Convert.ToInt32(reader["GIOITINH"]);
                    cn.NuocVe = reader["NUOCVE"].ToString();
                    cn.NamSinh = Convert.ToInt32(reader["NAMSINH"]);
                    reader.Close();
                }
                return cn;
            }
        }

        //UpdateCN
        public int UpdateCN(CONGNHAN cn,string MaCongNhanCu)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=clcovid;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "UPDATE CONGNHAN SET MACONGNHAN=@macn, TENCONGNHAN=@tencn, GIOITINH=@gt,NUOCVE=@nuocve,NAMSINH=@namsinh WHERE MACONGNHAN=@macnCu;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@macn", cn.MaCongNhan);
                cmd.Parameters.AddWithValue("@tencn", cn.TenCongNhan);
                //bool checkgt = false;
                //if(cn.GioiTinh==1) checkgt = true;
                cmd.Parameters.AddWithValue("@gt", cn.GioiTinh);
                cmd.Parameters.AddWithValue("@nuocve", cn.NuocVe);
                cmd.Parameters.AddWithValue("@namsinh", cn.NamSinh);
                cmd.Parameters.AddWithValue("@macnCu", MaCongNhanCu);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
