using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using pcomp;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace pcomp_gui
{
    public partial class Form1 : Form
    {
        //UserFile file1 = new UserFile();
        //UserFile file2 = new UserFile();

        public Form1()
        {
            InitializeComponent();
        }

        // 파일1 버튼 클릭.
        private void btnFile1_Click(object sender, EventArgs e)
        {
            if (false == SettingFileOpenDialog(1)) { return; }
        }

        // 파일2 버튼 클릭.
        private void btnFile2_Click(object sender, EventArgs e)
        {
            if (false == SettingFileOpenDialog(2)) { return; }
        }

        // 실행 버튼 클릭.
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // 입력 Check
            if (txtFile1.Text == "")
            {
                MessageBox.Show("파일1이 입력되지 않았습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtFile2.Text == "")
            {
                MessageBox.Show("파일2가 입력되지 않았습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 객체 생성 및 할당
            PCompare compare = new PCompare();
            // 파일 비교
            if (false == compare.Compare(txtFile1.Text, txtFile2.Text)) { return; }

            // 비교결과 텍스트박스에 출력
            txtResult.Text = compare.compareResult;

        }

        // 초기화 버튼 클릭.
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFile1.Text = null;
            txtFile2.Text = null;
            txtResult.Text = null;
        }

        // 비교내역 초기화 버튼 클릭.
        private void btnResultClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = null;
        }


        /// <summary>
        /// 파일오픈 창에서 텍스트 파일 경로를 가져온다.
        /// </summary>
        /// <remarks>
        /// 2017.04.10. 장민수 최초작성.
        /// </remarks>
        /// <returns>true: 정상, false: 비정상.</returns>
        public bool SettingFileOpenDialog(int selectFile)
        {
            try
            {
                if (selectFile != 1 && selectFile != 2)
                {
                    throw (new Exception("SettingFileOpenDialog 함수 호출 시, selectFile 인자값은 1,2 중에 선택하세요."));
                }

                // 파일오픈창 생성 및 설정
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "File Open";
                ofd.FileName = "";
                ofd.Filter = "텍스트 파일 (*.txt) | *.txt; | 모든 파일 (*.*) | *.*";

                // 파일 오픈창 로드
                DialogResult dr = ofd.ShowDialog();

                // OK버튼 클릭시
                if (dr == DialogResult.OK)
                {
                    // 파일1 텍스트박스에 경로 셋팅
                    if (selectFile == 1) { txtFile1.Text = ofd.FileName; }
                    // 파일2 텍스트박스에 경로 셋팅
                    else if (selectFile == 2) { txtFile2.Text = ofd.FileName; }
                }
                // 취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
                else if (dr == DialogResult.Cancel)
                {
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("예외 발생:" + e.Message);
                return false;
            }
            return true;
        }

    }
}
