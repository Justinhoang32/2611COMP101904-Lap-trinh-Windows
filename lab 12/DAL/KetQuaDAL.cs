using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu cho module kết quả học tập.
    /// Chỉ gọi stored procedure bằng parameter, không nối chuỗi SQL.
    /// </summary>
    public class KetQuaDAL
    {
        /// <summary>Lấy danh sách lớp (MaLop, TenLop).</summary>
        public DataTable GetLop()
        {
            using SqlConnection conn = Database.CreateConnection();
            using SqlCommand cmd = new SqlCommand("sp_Lop_GetAll", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            return Fill(cmd);
        }

        /// <summary>Lấy danh sách môn học (MaMon, TenMon, SoTinChi).</summary>
        public DataTable GetMonHoc()
        {
            using SqlConnection conn = Database.CreateConnection();
            using SqlCommand cmd = new SqlCommand("sp_MonHoc_GetAll", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            return Fill(cmd);
        }

        /// <summary>Lấy sinh viên của lớp kèm điểm môn học (nếu đã có).</summary>
        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            using SqlConnection conn = Database.CreateConnection();
            using SqlCommand cmd = new SqlCommand("sp_KetQua_GetByLopMon", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar, 20).Value = maLop;
            cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
            return Fill(cmd);
        }

        /// <summary>
        /// Lưu toàn bộ điểm trong MỘT transaction.
        /// Có bất kỳ dòng nào lỗi thì rollback tất cả và ném lại exception.
        /// Chỉ Commit một lần, sau khi mọi dòng đã lưu thành công.
        /// </summary>
        /// <returns>Số dòng đã lưu.</returns>
        public int SaveAll(string maMon, DataTable table)
        {
            using SqlConnection conn = Database.CreateConnection();
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();

            try
            {
                // Command phải gắn với transaction: new SqlCommand(sql, conn, trans)
                using SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter pMaSV = cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
                SqlParameter pDiem = cmd.Parameters.Add("@Diem", SqlDbType.Decimal);
                pDiem.Precision = 4;
                pDiem.Scale = 2;
                SqlParameter pGhiChu = cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255);

                int count = 0;
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    if (row.IsNull("Diem"))
                        throw new InvalidOperationException(
                            $"Điểm của sinh viên {row["MaSV"]} đang để trống.");

                    pMaSV.Value = row["MaSV"].ToString();
                    pDiem.Value = row["Diem"];
                    pGhiChu.Value = row["GhiChu"]?.ToString() ?? string.Empty;

                    cmd.ExecuteNonQuery();
                    count++;
                }

                trans.Commit();
                return count;
            }
            catch
            {
                try { trans.Rollback(); } catch { /* kết nối đã đứt thì bỏ qua */ }
                throw;
            }
        }

        private static DataTable Fill(SqlCommand cmd)
        {
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
