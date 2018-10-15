using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailVerteiler
{

    enum Data
    {
        Name,
        Vorname,
        PLZ
    }

    class CSVReader
    {

        List<User> users = null;

        public void ReadCSV(string filename)
        {
            string[] allLines = null;

            try
            {
                allLines = File.ReadAllLines(filename);
            }catch(Exception e)
            {
                MessageBox.Show("Schließen Sie bitte alle Anwendungen welche die Datei: "+filename+" geöffnet haben", "Warnung",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }

            users = new List<User>();

            for (int i = 1; i < allLines.Length; i++)
            {
                String[] values = allLines[i].Split(',');
                users.Add(new User(values));
            }

        }

        public void PopulateDataGridView(DataGridView gridView, string filter)
        {
            if (users == null)
                return;

            List<User> filteredUser = users;

            if (!String.IsNullOrEmpty(filter))
                filteredUser = users.Where(x => x.PLZ.Equals(filter)).ToList<User>();

            gridView.DataSource = filteredUser;

        }
    }
}
