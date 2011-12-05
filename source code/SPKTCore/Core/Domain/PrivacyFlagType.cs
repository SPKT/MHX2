using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Domain
{
    public partial class PrivacyFlagType
    {
        public enum PrivacyFlagTypes
        {
                FullName=1,
                Sex=2,
                Birthday=3,
                Signature=4,
                QueQuan=5,
                NoiOHienTai=6,
                CongViecHienTai=7,
                CongViecKhac=8,
                SoThichAmNhac=9,
                SoThichDienAnh=10,
                SoThichAmThuc=11,
                SoThichTheThao=12,
                SoThichKhac=13,
                DaiHoc=14,
                PhoThong=15,
                TrungHoc=16,
                TieuHoc=17,
                SoDienThoai=18,
                Yahoo=19,
                GioiThieuBanThan=20,
                WebSiteYeuThich=21
        }
    }
}
