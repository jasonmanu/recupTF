using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSupport
{
    public static class FormHelper
    {
        public static string GetCurrentRowId(DataGridView dataGrid)
        {
            DataGridViewRow currentRow = dataGrid?.CurrentRow;

            if (currentRow == null)
                return null;

            string currentRowId = Convert.ToString(currentRow.Cells["Id"]?.Value);
            return currentRowId;
        }
    }
}
