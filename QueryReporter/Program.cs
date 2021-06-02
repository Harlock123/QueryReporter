using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TAIQueryReporter
{
    static class Program
    {
        public static string TheEncryptedConnectionString = "";
        public static string TheConnectionStringDecrypted = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        public static string BraketizeKeywords(string wd)
        {
            string result = wd;

            if (result.Replace(" ", "") != result)
                result = "[" + result + "]";

            switch (result.ToUpper())
            {

                case "ADD":
                case "EXISTS":
                case "PRECISION":
                case "ALL":
                case "EXIT":
                case "PRIMARY":
                case "ALTER":
                case "EXTERNAL":
                case "PRINT":
                case "AND":
                case "FETCH":
                case "PROC":
                case "ANY":
                case "FILE":
                case "PROCEDURE":
                case "AS":
                case "FILLFACTOR":
                case "PUBLIC":
                case "ASC":
                case "FOR":
                case "RAISERROR":
                case "AUTHORIZATION":
                case "FOREIGN":
                case "READ":
                case "BACKUP":
                case "FREETEXT":
                case "READTEXT":
                case "BEGIN":
                case "FREETEXTTABLE":
                case "RECONFIGURE":
                case "BETWEEN":
                case "FROM":
                case "REFERENCES":
                case "BREAK":
                case "FULL":
                case "REPLICATION":
                case "BROWSE":
                case "FUNCTION":
                case "RESTORE":
                case "BULK":
                case "GOTO":
                case "RESTRICT":
                case "BY":
                case "GRANT":
                case "RETURN":
                case "CASCADE":
                case "GROUP":
                case "REVERT":
                case "CASE":
                case "HAVING":
                case "REVOKE":
                case "CHECK":
                case "HOLDLOCK":
                case "RIGHT":
                case "CHECKPOINT":
                case "IDENTITY":
                case "ROLLBACK":
                case "CLOSE":
                case "IDENTITY_INSERT":
                case "ROWCOUNT":
                case "CLUSTERED":
                case "IDENTITYCOL":
                case "ROWGUIDCOL":
                case "COALESCE":
                case "IF":
                case "RULE":
                case "COLLATE":
                case "IN":
                case "SAVE":
                case "COLUMN":
                case "INDEX":
                case "SCHEMA":
                case "COMMIT":
                case "INNER":
                case "SECURITYAUDIT":
                case "COMPUTE":
                case "INSERT":
                case "SELECT":
                case "CONSTRAINT":
                case "INTERSECT":
                case "SESSION_USER":
                case "CONTAINS":
                case "INTO":
                case "SET":
                case "CONTAINSTABLE":
                case "IS":
                case "SETUSER":
                case "CONTINUE":
                case "JOIN":
                case "SHUTDOWN":
                case "CONVERT":
                case "KEY":
                case "SOME":
                case "CREATE":
                case "KILL":
                case "STATISTICS":
                case "CROSS":
                case "LEFT":
                case "SYSTEM_USER":
                case "CURRENT":
                case "LIKE":
                case "TABLE":
                case "CURRENT_DATE":
                case "LINENO":
                case "TABLESAMPLE":
                case "CURRENT_TIME":
                case "LOAD":
                case "TEXTSIZE":
                case "CURRENT_TIMESTAMP":
                case "MERGE":
                case "THEN":
                case "CURRENT_USER":
                case "NATIONAL":
                case "TO":
                case "CURSOR":
                case "NOCHECK":
                case "TOP":
                case "DATABASE":
                case "NONCLUSTERED":
                case "TRAN":
                case "DBCC":
                case "NOT":
                case "TRANSACTION":
                case "DEALLOCATE":
                case "NULL":
                case "TRIGGER":
                case "DECLARE":
                case "NULLIF":
                case "TRUNCATE":
                case "DEFAULT":
                case "OF":
                case "TSEQUAL":
                case "DELETE":
                case "OFF":
                case "UNION":
                case "DENY":
                case "OFFSETS":
                case "UNIQUE":
                case "DESC":
                case "ON":
                case "UNPIVOT":
                case "DISK":
                case "OPEN":
                case "UPDATE":
                case "DISTINCT":
                case "OPENDATASOURCE":
                case "UPDATETEXT":
                case "DISTRIBUTED":
                case "OPENQUERY":
                case "USE":
                case "DOUBLE":
                case "OPENROWSET":
                case "USER":
                case "DROP":
                case "OPENXML":
                case "VALUES":
                case "DUMP":
                case "OPTION":
                case "VARYING":
                case "ELSE":
                case "OR":
                case "VIEW":
                case "END":
                case "ORDER":
                case "WAITFOR":
                case "ERRLVL":
                case "OUTER":
                case "WHEN":
                case "ESCAPE":
                case "OVER":
                case "WHERE":
                case "EXCEPT":
                case "PERCENT":
                case "WHILE":
                case "EXEC":
                case "PIVOT":
                case "WITH":
                case "EXECUTE":
                case "PLAN":
                case "WRITETEXT":
                    result = "[" + result + "]";
                    break;
                default:
                    break;
            }


            return result;
        }
    }

    public class GraphItem
    {

        private string _Name = "";
        private double _Valu = 0.0;

        public GraphItem(string thename, double thevalue)
        {
            _Name = thename;
            _Valu = thevalue;
        }

        public double TheValue
        {
            get { return _Valu; }
            set { _Valu = value; }
        }

        public string TheName
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public override string ToString()
        {
            return TheName;
        }

    }

}
