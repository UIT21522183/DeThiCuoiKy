namespace DeThiCuoiKy.Models
{
	public class CONGNHAN
	{
		public string MaCongNhan { get; set; }
		public string TenCongNhan { get; set; }
		public int GioiTinh { get; set; }
		public int NamSinh { get; set; }
		public string NuocVe { get; set; }
		public string MaDiemCachLy { get; set; }
        public CONGNHAN() { }
        public CONGNHAN(string MaCongNhan = "", string TenCongNhan = "",int GioiTinh=0,
						int NamSinh=0,string NuocVe = "",string MaDiemCachLy = "")
        {
			this.MaCongNhan = MaCongNhan;
			this.TenCongNhan= TenCongNhan;
			this.GioiTinh = GioiTinh;
			this.NamSinh=NamSinh;
			this.NuocVe = NuocVe;
			this.MaDiemCachLy= MaDiemCachLy;
        }

    }
}
