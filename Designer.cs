using System.Windows.Forms;

namespace assignment3
{
    public class Designer
    {
        public static void StyleBtn(Button btn)
        {
            btn.Anchor = AnchorStyles.None;
            btn.BackColor = System.Drawing.Color.Black;
            btn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            btn.UseVisualStyleBackColor = false;
        }
    }
}
