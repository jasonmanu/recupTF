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
        public static int? GetCurrentRowId(DataGridView dataGrid)
        {
            DataGridViewRow currentRow = dataGrid?.CurrentRow;

            if (currentRow == null)
                return null;

            int? currentRowId = Convert.ToInt32(currentRow.Cells["Id"]?.Value);
            return currentRowId;
        }
    }
}
