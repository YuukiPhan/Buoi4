using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLNS
{
    public partial class Form1 : Form
    {
        List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo dữ liệu mẫu (có thể thay đổi)
            danhSachNhanVien.Add(new NhanVien() { MSNV = "NV001", TenNV = "Nguyễn Văn A", LuongCB = 5000000 });
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            listView1.Items.Clear();
            foreach (NhanVien nv in danhSachNhanVien)
            {
                ListViewItem item = new ListViewItem(nv.MSNV);
                item.SubItems.Add(nv.TenNV);
                item.SubItems.Add(nv.LuongCB.ToString());
                listView1.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVienMoi = new NhanVien();
            FormNhanVien frmNhanVien = new FormNhanVien(nhanVienMoi);
            if (frmNhanVien.ShowDialog() == DialogResult.OK)
            {
                danhSachNhanVien.Add(frmNhanVien.NhanVienMoi);
                HienThiDanhSach();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nhanVienMoi = new NhanVien();
            FormNhanVien frmNhanVien = new FormNhanVien(nhanVienMoi);
            if (frmNhanVien.ShowDialog() == DialogResult.OK)
            {
                danhSachNhanVien.Add(frmNhanVien.NhanVienMoi);
                HienThiDanhSach();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string msnv = item.SubItems[0].Text;
                NhanVien nv = danhSachNhanVien.Find(x => x.MSNV == msnv);

                if (nv != null)
                {
                    FormNhanVien frmNhanVien = new FormNhanVien(nv);
                    if (frmNhanVien.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật thông tin nhân viên
                        int index = danhSachNhanVien.FindIndex(x => x.MSNV == msnv);
                        if (index != -1)
                        {
                            danhSachNhanVien[index] = frmNhanVien.NhanVienMoi;
                            HienThiDanhSach();
                            MessageBox.Show("Đã cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi lựa chọn thay đổi (nếu cần)
        }

        private void XoaNhanVien(string msnv)
        {
            if (danhSachNhanVien.RemoveAll(x => x.MSNV == msnv) > 0)
            {
                MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string msnv = item.SubItems[0].Text;

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    XoaNhanVien(msnv);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class NhanVien
    {
        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public int LuongCB { get; set; }
    }
}