namespace DeThiCuoiKy.Models
{
	public class DIEMCACHLY
	{
		public string MaDiemCachLy { get; set; }
		public string TenDiemCachLy { get; set; }
		public string DiaChi {  get; set; }

        public DIEMCACHLY(string MaDiemCachLy="",string TenDiemCachLy = "",string DiaChi = "") 
		{
			this.MaDiemCachLy = MaDiemCachLy;
			this.TenDiemCachLy =(string)TenDiemCachLy;
			this.DiaChi =(string)DiaChi;
		}
	}
}
