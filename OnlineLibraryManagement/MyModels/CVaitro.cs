namespace OnlineLibraryManagement.MyModels
{
    public class CVaitro
    {
        public static List<string> getDSVaitro()
        {
            List<string> ds = new List<string>();
            ds.Add("Tác giả chính");
            ds.Add("Tác giả phụ");
            ds.Add("Biên tập viên");
            ds.Add("Dịch giả");
            ds.Add("Người giới thiệu");
            ds.Add("Nhà nghiên cứu");
            ds.Add("Nhà soạn thảo");
            return ds;
        }
    }
}
