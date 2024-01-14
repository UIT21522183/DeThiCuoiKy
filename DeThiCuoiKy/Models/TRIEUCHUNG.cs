namespace DeThiCuoiKy.Models
{
	public class TRIEUCHUNG
	{
		public string MaTrieuChung { get; set; }
		public string TenTrieuChung {  set; get; }

		public TRIEUCHUNG(string MaTrieuChung="",string TenTrieuChung="") 
		{
			this.MaTrieuChung = MaTrieuChung;
			this.TenTrieuChung = TenTrieuChung;
		}
	}
}
