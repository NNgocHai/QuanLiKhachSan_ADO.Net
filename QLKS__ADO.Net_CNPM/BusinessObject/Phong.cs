using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS__ADO.Net_CNPM.BusinessObject
{
    class Phong
    {
        private string ma_Phong;
        private string ten;
        private int gia;
        private string tinhTrang;
        private string soNguoiToiDa;
        private string phong_KM;
        private string moTa;

        public string Ma_Phong { get => ma_Phong; set => ma_Phong = value; }
        public string Ten { get => ten; set => ten = value; }
        public int Gia { get => gia; set => gia = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string SoNguoiToiDa { get => soNguoiToiDa; set => soNguoiToiDa = value; }
        public string Phong_KM { get => phong_KM; set => phong_KM = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
