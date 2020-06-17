using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToolsLib.HelpExcel
{
    public class OledbExcelHelper
    {
        /// <summary>
        /// 将Excel文件上传，并读取到DataTable ，采用OLEDB
        /// </summary>
        /// <param name="strExcelFile">文件路径</param>
        /// <returns>将Excel文件处理到DataTable并返回</returns>
        public static DataTable ExcelToDataTable(string strExcelFile)
        {
            try
            {
                if (string.IsNullOrEmpty(strExcelFile))
                {
                    return null;
                    //throw new ArgumentNullException("Excel文件上传失败！--文件名获取失败 ");
                }


                string strExcelConn = string.Empty;
                /*
                 * HDR=Yes;//第一行包含列名
                 * IMEX = 0; //写入
                 * IMEX = 1; //读取
                 * IMEX = 2; //两者
                 * */
                string _strExtension = System.IO.Path.GetExtension(strExcelFile);//文件扩展名
                switch (_strExtension)
                {
                    case ".xlsx":
                        //2007以上版本（Microsoft.ACE.OLEDB.12.0）
                        strExcelConn = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={strExcelFile};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";

                        break;
                    default:
                        //2003（Microsoft.Jet.Oledb.4.0）
                        strExcelConn = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={strExcelFile};Extended Properties='Excel 8.0;HDR=yes;IMEX=1;'";
                        break;
                }
                
                OleDbConnection oleDBConn = null;
                OleDbDataAdapter oleAdMaster = null;
                DataTable m_tableName = new DataTable();
                DataSet ds = new DataSet();

                oleDBConn = new OleDbConnection(strExcelConn);
                oleDBConn.Open();
                m_tableName = oleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (m_tableName != null && m_tableName.Rows.Count > 0)
                {

                    m_tableName.TableName = m_tableName.Rows[0]["TABLE_NAME"].ToString();

                }
                string sqlMaster;
                sqlMaster = " SELECT *  FROM [" + m_tableName.TableName + "]";
                oleAdMaster = new OleDbDataAdapter(sqlMaster, oleDBConn);
                oleAdMaster.Fill(ds, "m_tableName");
                oleAdMaster.Dispose();
                oleDBConn.Close();
                oleDBConn.Dispose();

                return (ds != null && ds.Tables.Count > 0) ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static void DataTableToExcel(string excelTempFilePath, DataTable dt)
        {
            string strExcelConn = string.Empty;
            string _strExtension = System.IO.Path.GetExtension(excelTempFilePath);//文件扩展名
            switch (_strExtension)
            {
                case ".xlsx":
                    //2007以上版本（Microsoft.ACE.OLEDB.12.0）
                    strExcelConn = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelTempFilePath};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";

                    break;
                default:
                    //2003（Microsoft.Jet.Oledb.4.0）
                    strExcelConn = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={excelTempFilePath};Extended Properties='Excel 8.0;HDR=yes;IMEX=1;'";
                    break;
            }


            int rowNum = dt.Rows.Count;//获取行数
            int colNum = dt.Columns.Count;//获取列数
            string sqlText = "";//带类型的列名
            string sqlValues = "";//值
            string colCaption = "";//列名
            for (int i = 0; i < colNum; i++)
            {
                if (i != 0)
                {
                    sqlText += " , ";
                    colCaption += " , ";
                }
                sqlText += "[" + dt.Columns[i].Caption.ToString() + "] VarChar";//生成带VarChar列的标题
                colCaption += "[" + dt.Columns[i].Caption.ToString() + "]";//生成列的标题
            }

            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strExcelConn);
            OleDbCommand cmd = null;
            
            try
            {
                conn.Open();
                
                string strSQL = "CREATE TABLE [Sheet1] (" + sqlText + ")";
                cmd = new OleDbCommand(strSQL, conn);

                cmd.ExecuteNonQuery();
                for (int srow = 0; srow < dt.Rows.Count; srow++)
                {
                    sqlValues = "";
                    for (int col = 0; col < colNum; col++)
                    {
                        if (col != 0)
                        {
                            sqlValues += " , ";
                        }
                        sqlValues += "'" + dt.Rows[srow][col].ToString() + "'";//拼接Value语句
                    }
                    String queryString = "INSERT INTO [Sheet1] (" + colCaption + ") VALUES (" + sqlValues + ")";
                    cmd.CommandText = queryString;
                    cmd.ExecuteNonQuery();//插入数据
                }
            }
            catch (Exception er)
            {
                //Response.Write(er.Message);
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                conn.Dispose();

            }
        }
    }
}
