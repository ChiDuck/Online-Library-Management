namespace OnlineLibraryManagement.MyModels
{
	public class CVaitro
	{
		public static List<string> getDSVaitro()
		{
			List<string> ds = new()
			{
				"Tác giả chính",
				"Tác giả phụ",
				"Biên tập viên",
				"Dịch giả",
				"Người giới thiệu",
				"Nhà nghiên cứu",
				"Nhà soạn thảo"
			};
			return ds;
		}
	}
}
