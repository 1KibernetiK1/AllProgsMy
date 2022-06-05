using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryCommand;

namespace ProjectWinFormsCommands
{
    public partial class Form1 : Form
    {
        // наша Форма - UI
        // привязана к Бизнес
        // логике ч/х посредника -
        // менеджер команд
        private BusinessLogic bl;
        private CommandManager cm;

        public Form1()
        {
            InitializeComponent();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            bl = new BusinessLogic();
            cm = new CommandManager();
            #region Создадим команды
            var cmdCreate = new
                CommandWrapper("Создать",
                               bl.CanCreateOrLoad,
                               bl.CreateFile);
            var cmdLoad = new
                CommandWrapper("Загрузить",
                               bl.CanCreateOrLoad,
                               bl.LoadFile);
            var cmdClose = new
                CommandWrapper("Закрыть",
                               bl.CanClose,
                               bl.CloseFile);
            var cmdSave = new
                CommandWrapper("Сохранить",
                               bl.CanSave,
                               bl.SaveFile);
            var cmdEdit = new
                CommandWrapper("Редактировать",
                               bl.CanEdit,
                               bl.EditFile);
            #endregion
            #region Привязка команд
            cm.Bind(cmdCreate, button1, createToolStripMenuItem, createToolStripMenuItem1);
            cm.Bind(cmdLoad, button2, loadToolStripMenuItem, loadToolStripMenuItem1);
            cm.Bind(cmdEdit, button3, editToolStripMenuItem, editToolStripMenuItem1);
            cm.Bind(cmdSave, button4, saveToolStripMenuItem, saveToolStripMenuItem1);
            cm.Bind(cmdClose, button5, closeToolStripMenuItem, closeToolStripMenuItem1);
            #endregion
        }
    }
}
