@Code
    Dim treeList As TreeListExtension = Html.DevExpress().TreeList( _
        Sub(settings)
                settings.Name = "TreeList"
                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "TreeListPartial"}

                settings.KeyFieldName = "EmployeeID"
                settings.ParentFieldName = "SupervisorID"

                settings.Columns.Add("FirstName")
                settings.Columns.Add("MiddleName")
                settings.Columns.Add("LastName")
                settings.Columns.Add("Title")

                settings.SettingsEditing.AddNewNodeRouteValues = New With {.Controller = "Home", .Action = "TreeListPartialAddNew"}
                settings.SettingsEditing.UpdateNodeRouteValues = New With {.Controller = "Home", .Action = "TreeListPartialUpdate"}
                settings.SettingsEditing.NodeDragDropRouteValues = New With {.Controller = "Home", .Action = "TreeListPartialMove"}
                settings.SettingsEditing.DeleteNodeRouteValues = New With {.Controller = "Home", .Action = "TreeListPartialDelete"}

                settings.CommandColumn.Visible = True
                settings.CommandColumn.ShowNewButtonInHeader = True
                settings.CommandColumn.NewButton.Visible = True
                settings.CommandColumn.DeleteButton.Visible = True
                settings.CommandColumn.EditButton.Visible = True

                settings.SettingsText.ConfirmDelete = "Are you sure?"
        End Sub)
    If (ViewData("EditNodeError") IsNot Nothing) Then
        treeList.SetEditErrorText(CType(ViewData("EditNodeError"), String))
    End If
End Code
@treeList.Bind(Model).GetHtml()