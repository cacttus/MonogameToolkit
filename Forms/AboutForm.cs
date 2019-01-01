using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monoedit
{
    public partial class AboutForm : MonoEditForm
    {
        public static DateTime GetLinkerTime( Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            _btnOk.Select();
            ShowAboutText();
            ShowErrors();
        }
        private void ShowErrors()
        {
            string str = "";
            foreach(string e in Globals.MainForm.Errors)
            {
                str += e + Environment.NewLine;
            }

            _txtErrors.Text = str;
        }
        private void ShowAboutText()
        {

            DateTime buildTime = GetLinkerTime(Assembly.GetExecutingAssembly()); ;
            string buildTimeStr = buildTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss \"GMT\"zzz");

            string mit_eng = "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";
            string mit_esp = "EL SOFTWARE SE PROPORCIONA \"COMO ESTÁ\", SIN GARANTÍA DE NINGÚN TIPO, EXPRESA O IMPLÍCITA, INCLUYENDO PERO NO LIMITADO A GARANTÍAS DE COMERCIALIZACIÓN, IDONEIDAD PARA UN PROPÓSITO PARTICULAR E INCUMPLIMIENTO. EN NINGÚN CASO LOS AUTORES O PROPIETARIOS DE LOS DERECHOS DE AUTOR SERÁN RESPONSABLES DE NINGUNA RECLAMACIÓN, DAÑOS U OTRAS RESPONSABILIDADES, YA SEA EN UNA ACCIÓN DE CONTRATO, AGRAVIO O CUALQUIER OTRO MOTIVO, DERIVADAS DE, FUERA DE O EN CONEXIÓN CON EL SOFTWARE O SU USO U OTRO TIPO DE ACCIONES EN EL SOFTWARE.";

            Phrase p = new Phrase(
                Globals.ProgramName + Environment.NewLine
                + "v" + Globals.ProgramVersion + Environment.NewLine
                + "Derek & Ronelle Page" + Environment.NewLine
                + "Build Date: " + buildTimeStr + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine
                + "Licence:" + Environment.NewLine
                + mit_eng
                ,
                Globals.ProgramName + Environment.NewLine
                + "v" + Globals.ProgramVersion + Environment.NewLine
                + "Derek & Ronelle Page" + Environment.NewLine
                + "Fecha de Construcción: " + buildTimeStr + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine
                + "Licencia:" + Environment.NewLine
                + mit_esp
                );

            _txtAbout.Text = Translator.Translate(p);
        }


        private void _txtAbout_Click(object sender, EventArgs e)
        {

        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void _btnClearErrors_Click(object sender, EventArgs e)
        {
            Globals.MainForm.Errors.Clear();
            _txtErrors.Clear();
        }
    }
}
