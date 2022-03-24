using System.Data.OleDb;

namespace GEN_Planlama
{
    class OleDbBaglantisi
    {
        public OleDbConnection baglanti()
        {
            OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Y:\BILGI TEKNOJILERI PROGRAMLAR\Database\PLANLAMA.xlsx;Extended Properties='Excel 12.0 Xml; HDR = YES';");
            baglan.Open();
            return baglan;
        }
    }
}
