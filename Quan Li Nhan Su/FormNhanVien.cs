using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormNhanVien : Form
    {
        public NhanVien NhanVienMoi { get; set; }

        public FormNhanVien(NhanVien nv)
        {
            InitializeComponent();

            // Kiểm tra xem nv có phải null không
            if (nv == null)
            {
                MessageBox.Show("Dữ liệu nhân viên không hợp lệ.");
                return;
            }

            NhanVienMoi = new NhanVien();
            NhanVienMoi.MSNV = nv.MSNV ?? string.Empty;
            NhanVienMoi.TenNV = nv.TenNV ?? string.Empty;
            NhanVienMoi.LuongCB = nv.LuongCB;

            // Gán giá trị cho các textbox
            txtMSNV.Text = NhanVienMoi.MSNV;
            txtTenNhanVien.Text = NhanVienMoi.TenNV;
            txtLuongCB.Text = NhanVienMoi.LuongCB.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra lại xem NhanVienMoi đã được khởi tạo chưa
            if (NhanVienMoi == null)
            {
                MessageBox.Show("Lỗi: NhanVienMoi chưa được khởi tạo.");
                return;
            }

            // Cập nhật thông tin nhân viên
            NhanVienMoi.MSNV = txtMSNV.Text;
            NhanVienMoi.TenNV = txtTenNhanVien.Text;
            // Kiểm tra và xử lý lỗi khi chuyển đổi chuỗi thành số
            if (int.TryParse(txtLuongCB.Text, out int luongCB))
            {
                NhanVienMoi.LuongCB = luongCB;
            }
            else
            {
                MessageBox.Show("Lương phải là số nguyên.");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMSNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
