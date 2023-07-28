using Demo_Project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Demo_Project.Pages
{
    public partial class Home : System.Web.UI.Page
    {

        private static User user;
        public String userName;
        public int noteCount;
        private MySqlDbHelper dbHelper;
        private static int noteId;
        private static String noteTitle;
        private static String noteDescription;
        

        private void FetchNotes()
        {
            DataTable noteDataTable = new DataTable();

            bool isGetNote = dbHelper.GetNotes(ref noteDataTable, user.Id);

            noteId = 0;


            if (noteDataTable.Rows.Count > 0)
            {
                noteDataTable = (from note in noteDataTable.AsEnumerable() orderby note.Field<String>("TITLE") select note).CopyToDataTable();
            }

            noteCount = noteDataTable.Rows.Count;

            if (isGetNote)
            {
                dlNoteList.DataSource = noteDataTable;
                dlNoteList.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object userData = Session["userData"];

            if (userData == null)
            {
                Session.Abandon();
                Response.Redirect("~/MasterForm.aspx");
            }

            String userDataJson = userData.ToString();
            user = JsonConvert.DeserializeObject<User>(userDataJson);

            userName = user.Name + " " + user.Surname;

            dbHelper = new MySqlDbHelper();

            if (!IsPostBack)
            {
                FetchNotes();
            }
                
        }

        protected void DlNoteList_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            noteId = Convert.ToInt32(dlNoteList.DataKeys[e.Item.ItemIndex]);
            deleteNoteModal.Attributes.Add("class", "modal is-active");
        }

        protected void BtnAddNote_Click(object sender, EventArgs e)
        {
            addNoteTitle.Value = "";
            addNoteDescription.Value = "";
            addNoteModal.Attributes.Add("class", "modal is-active");
        }



        protected void DeleteNoteModalCancel_Click(object sender, EventArgs e)
        {
            deleteNoteModal.Attributes["class"] = "modal";
        }

        protected void deleteNoteModalDelete_Click(object sender, EventArgs e)
        {
            deleteNoteModal.Attributes["class"] = "modal";
            if (dbHelper.DeleteNote(noteId))
            {
                dlNoteList.EditItemIndex = -1;
                FetchNotes();
            }
        }

        protected void btnAddNoteModal_Click(object sender, EventArgs e)
        {
            addNoteModal.Attributes["class"] = "modal";
            if (dbHelper.AddNote(user.Id, addNoteTitle.Value, addNoteDescription.Value))
            {
                dlNoteList.EditItemIndex = -1;
                FetchNotes();
            }
        }

        protected void btnAddNoteCancelModal_Click(object sender, EventArgs e)
        {
            addNoteModal.Attributes["class"] = "modal";
        }

        protected void btnUpdateNoteModal_Click(object sender, EventArgs e)
        {
            updateNoteModal.Attributes["class"] = "modal";

            if (dbHelper.UpdateNote(noteId, updateNoteTitle.Value, updateNoteDescription.Value))
            {
                dlNoteList.EditItemIndex = -1;
                FetchNotes();
            }
        }

        protected void btnUpdateNoteModalCancel_Click(object sender, EventArgs e)
        {
            updateNoteModal.Attributes["class"] = "modal";
        }

        protected void btnUpdateNote_Click(object sender, EventArgs e)
        {
            updateNoteTitle.Value = "";
            updateNoteDescription.Value = "";
            updateNoteModal.Attributes.Add("class", "modal is-active");
        }

        protected void dlNoteList_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            noteId = Convert.ToInt32(dlNoteList.DataKeys[e.Item.ItemIndex]);

            Note note = dbHelper.GetNote(noteId);

            if (note != null)
            {
                noteTitle = note.Title;
                noteDescription = note.Description;
            }
            else
            {
                noteId = 0;
                noteTitle = "";
                noteDescription = "";
            }

            updateNoteTitle.Value = noteTitle;
            updateNoteDescription.Value = noteDescription;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["userData"] = null;
            Session.Abandon();
            Response.Redirect("~/MasterForm.aspx");
        }
    }
}