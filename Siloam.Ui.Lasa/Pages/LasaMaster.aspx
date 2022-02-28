<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LasaMaster.aspx.cs" Inherits="Siloam.Ui.Lasa.Pages.LasaMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--###########################################################################################################################################-->
    <!------------------------------------------------------------------ The Script ----------------------------------------------------------------->

    <script type="text/javascript">

        function AddDetail(salesid, transname) {
            $('#modalMapingLasa').modal('show')

            var Hidden_sales_id = document.getElementById('<%= HiddenField_SalesId.ClientID %>');
            var Label_drag_name_add = document.getElementById('<%= Label_drug_name_add.ClientID %>');
          
            Hidden_sales_id.value = salesid;
            Label_drag_name_add.innerHTML = transname;
         
            return false
        }


        //menampilkan data ke modal
        function EditDetail(transId, transname, transislasa, transmodif) {
            $('#modalEditLasa').modal('show')


            var Hidden_trans_id = document.getElementById('<%= HiddenTransactionID.ClientID %>');
            var Label_drag_name_edit = document.getElementById('<%= Label_drag_name_edit.ClientID %>');
            var Label_modif_edit = document.getElementById('<%= Label_last_modif.ClientID %>');
          
            var Rb_lasa = document.getElementById('<%= Rb_is_lasa_edit.ClientID %>');
            var radio_edit = Rb_lasa.getElementsByTagName("input");

         
               
            Hidden_trans_id.value = transId;
            Label_drag_name_edit.innerHTML = transname;
            Label_modif_edit.innerHTML = transmodif;


            if (transislasa == "True") {
                radio_edit[0].checked = true;
            }
            else if (transislasa == "False") {
                radio_edit[1].checked = true;
            }
            else {
                radio_edit[0].checked = false;
                radio_edit[1].checked = false;
            }


        }

        //fungsi  untuk validasi input text kosong, lalu menampilkan notifikasi text berwarna merah
        function AddFormCheck() {
            var Rb_edit_lasa = document.getElementById('<%= Add_RadioButtonList.ClientID %>');
            var radio = Rb_edit_lasa.getElementsByTagName("input");

            if (radio[0].checked == false && radio[1].checked == false)
            {
                $("[id$='p_Add']").removeAttr("style");
                $("[id$='p_Add']").attr("style", "display:block; color:red;");
                document.getElementById('<%= p_Add.ClientID %>').innerHTML = "please choice lasa or not!";
                return false;
            }
        }

        //fungsi  untuk validasi input text kosong ketika edit, lalu menampilkan notifikasi text berwarna merah
        <%--function EditFormCheck() {
            var Rb_lasa = document.getElementById('<%= Rb_is_lasa_edit.ClientID %>');
            var radio = Rb_lasa.getElementsByTagName("input");

            if (radio[0].checked == false && radio[1].checked == false)
            {
                $("[id$='p_Add']").removeAttr("style");
                $("[id$='p_Add']").attr("style", "display:block; color:red;");
                document.getElementById('<%= p_Add.ClientID %>').innerHTML = "please choice lasa or not!";
                return false;
            }
        }--%>

        //fungsi untuk klik button search by enter button
        function cariData(evt) {
            evt = (evt) ? evt : window.event;
            var key = evt.keyCode || evt.charCode;
            if (key == 13) {
                document.getElementById('<%= ButtonCari.ClientID %>').click();
             }

             if (document.getElementById('<%= Search_masterData.ClientID %>').value == "") {
                 document.getElementById('<%= ButtonCari.ClientID %>').click();
            }
        }

        //fungsi untuk me reset form input dan notifikasi menjadi kosong kembali
        function resetModalForm() {
            $("[id$='p_Add']").removeAttr("style");
            document.getElementById('<%= p_Add.ClientID %>').innerHTML = "";

            //fungsi mempertahankan style dropdown search
            $('.selectpicker').selectpicker('refresh');
        }


        //fungsi event klik pada area diluar modal
        $(document).ready(function () {
            $('#modalEditLasa').on('hidden.bs.modal', function (e) {
                resetModalForm();
            });

            $('#modalMapingLasa').on('hidden.bs.modal', function (e) {
                resetModalForm();
            });

        });

        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }

    </script>

    <style>
        .pagination-ys {
            /*display: inline-block;*/
            margin-left: auto !important;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 4px 8px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #7A7A7A;
                    background-color: #ffffff;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 4px 8px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #fff;
                    background-color: #1D2567;
                    cursor: default;
                }
               /* why*/
                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                   
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #fff;
                    background-color: #1D2567;
                }

                input[type="radio"] {
                    background-color: #FFFF99;
                    color: Navy;
                }

                .rbl input[type="radio"] {
                    margin-right: 5px;
                }

                .rows
                {
                    border-bottom: 0.5px solid #F0F1F7;
                    min-height: 25px;
                }

                .header-grid
                {
                    background-color: #F0F1F7;
                   
                }

                .btn-edit-lasa
                {
                    background-color:#1A2268;
                    width:101px; 
                    color: white;
                    text-transform: uppercase;
                    border-radius: 4px;
                }

                .icon-search {
                    position:absolute;
                    margin-top:10px;
                    margin-left:7px;
                }

    </style>


    <!--###########################################################################################################################################-->
    <!------------------------------------------------------------------ The Content ---------------------------------------------------------------->

    <div class="login-box-body" style="margin-top: 10px">
        <div class="row">
            <div class="col-sm-12">

                <div class="row" style="padding-top: 10px; padding-bottom: 10px">
                    <div class="col-sm-6 TeksHeader" style="padding-top: 5px;">
                        <b style="float: left">LASA MEDICATION LIST </b>

                        <%--update progress untuk menunggu loading pindah page--%>
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePaneDataOrg">
                            <ProgressTemplate>
                                <img alt="" height="25px" width="25px" style="background-color: transparent; vertical-align: middle" src="<%= Page.ResolveClientUrl("~/Assets/loading.gif") %>" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanelCari">
                            <ProgressTemplate>
                                <img alt="" height="25px" width="25px" style="background-color: transparent; vertical-align: middle" src="<%= Page.ResolveClientUrl("~/Assets/loading.gif") %>" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                    </div>
                    <%--search--%>
                    <div class="col-sm-6" style="text-align: right;">
                        <%--style="display: inline-flex;"--%>
                        <div class="form-inline" >
                            <div class="has-feedback" style="text-align: right; margin-right: 10px;">
                                <span class="fa fa-search icon-search"></span>
                                <asp:TextBox ID="Search_masterData" Style="width:300px; padding-left:30px" name="Search_masterData" runat="server" CssClass="form-control" onkeyup="cariData(event)" placeholder="Search By Drug Name" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanelCari" runat="server">
                                <ContentTemplate>
                                    <div hidden>
                                        <asp:Button ID="ButtonCari" runat="server" Text="Button" OnClick="ButtonCari_Click" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFlagCari" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePaneDataOrg" runat="server" UpdateMode="Always">
                    <ContentTemplate>

                        <asp:GridView
                            ID="GridViewLasa"
                            runat="server"
                            AutoGenerateColumns="False"
                            CssClass="table TeksNormal"
                            AllowPaging="True"
                            PageSize="30"
                            RowStyle-CssClass="rows"
                            OnPageIndexChanging="GridViewLasa_PageIndexChanging"
                            ShowHeaderWhenEmpty="True"
                            DataKeyNames="SalesItemId"
                            EmptyDataText="No Data"
                            HeaderStyle-CssClass="header-grid"
                            BorderWidth="0">
                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                            <PagerSettings  PageButtonCount="5" Mode="NumericFirstLast"  FirstPageText="<" LastPageText=">"/> 
                            <Columns>
                                <asp:BoundField HeaderText="SalesItemID" HeaderStyle-CssClass="TeksHeaderTable" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Left" DataField="SalesItemId" SortExpression="SalesItemId" ItemStyle-BorderWidth="0" HeaderStyle-BorderWidth="0"></asp:BoundField>
                                <asp:BoundField HeaderText="Drug Name" HeaderStyle-CssClass="TeksHeaderTable" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Left" DataField="name" SortExpression="name" ItemStyle-BorderWidth="0" HeaderStyle-BorderWidth="0"></asp:BoundField>

                                <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="TeksHeaderTable" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" ItemStyle-BorderWidth="0" HeaderStyle-BorderWidth="0">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("is_lasa").ToString() == "" || Eval("is_lasa").ToString() == "False"  ? "-" : "LASA" %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Last Modified" HeaderStyle-CssClass="TeksHeaderTable" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left" ItemStyle-BorderWidth="0" HeaderStyle-BorderWidth="0">
                                    <ItemTemplate>
                                        <asp:Label ID="Label_date" Text='<%# Eval("modified").ToString() == ""  ? "-" : Convert.ToDateTime(Eval("modified")).ToString("dd/MM/yyyy - HH:mm") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%" HeaderStyle-ForeColor="#1a2269" ItemStyle-HorizontalAlign="center" ItemStyle-BorderWidth="0" HeaderStyle-BorderWidth="0" HeaderStyle-CssClass="text-center TeksHeaderTable">
                                    <ItemTemplate>
                                        <a href="#" class="btn btn-success btn-sm" data-toggle="modal" onclick="<%# "AddDetail('" + Eval("SalesItemId").ToString() + "','" + Eval("name").ToString().Replace(" "," ")  + "')" %>" style='<%# Eval("modified").ToString() == "" ? "display:inline": "display:none"%>'><span style="padding: 0 10px 0 10px">MAP</span></a>
                                        <a href="#" data-toggle="modal" onclick="<%# "EditDetail('" + Eval("item_id").ToString() + "','" + Eval("name").ToString().Replace(" "," ")  + "','"  + Eval("is_lasa") +"','"  + Eval("modified").ToString().Replace(" "," ") + "')" %>" style='<%# Eval("modified").ToString() != "" ? "display:inline": "display:none"%>'><span style="color: #2A3593; font-weight: 600; font-size: 12px">EDIT</span></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                         

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!--###########################################################################################################################################-->
    <!------------------------------------------------------------------ The Modal ------------------------------------------------------------------>

     <!-- ##### Modal Add lasa ##### -->
    <div class="modal fade" id="modalMapingLasa" role="dialog" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 50px;" data-keyboard="false">

        <div class="modal-dialog" style="width: 500px">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="return resetModalForm()">×</button>
                    <h4 class="modal-title">
                        <label>LASA MEDICATION LIST</label>
                    </h4>
                </div>

                <!-- Modal body -->
                <div class="modal-body">

                    <!-- update panel ini berfungsi untuk menjaga item didalamnya tidak terrefresh oleh postback dari luar update panel ini -->
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="HiddenField_SalesId" runat="server" />
                            <table class="table text-left" style="margin-top: -15px;">
                                <tr>
                                    <td style="width: 30%; border-width: 0;">Drug Name</td>
                                    <td style="border-width: 0;">:</td>
                                    <td style="border-width: 0;">
                                    
                                        <asp:Label ID="Label_drug_name_add" runat="server" Text="">Label</asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="border-width: 0;">Is Lasa?</td>
                                    <td style="border-width: 0;">:</td>
                                    <td style="border-width: 0;">
                                        <asp:RadioButtonList ID="Add_RadioButtonList" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                            <asp:ListItem ID="add_yes_lasa" Text="Yes" Value="True"></asp:ListItem>
                                            <asp:ListItem ID="add_no_lasa" Text="No" Value="False" Style="margin-left: 20px; font-weight: lighter"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                
                            </table>

                            <!-- dipasangi update panel agar element didalamnya dapat diupdate dari server side dan tidak terrefresh oleh postback -->
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <b>
                                        <p style="color: red; display: none" id="p_Add" runat="server"></p>
                                    </b>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanelSAVAdd" runat="server">
                                <ContentTemplate>
                                    <div class="text-right">
                                        <asp:Button ID="Add_ButtonSaveLasa" runat="server" Text="Save" ForeColor="White" class="btn btn-edit-lasa " OnClientClick="return AddFormCheck()" OnClick="Add_ButtonSaveLasa_Click"></asp:Button>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <%--update progress yang berbentuk modal hanya untuk button save--%>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelSAVAdd">
                                <ProgressTemplate>
                                    <div class="modal-backdrop" style="background-color: black; opacity: 0.4; text-align: center">
                                        <img alt="" height="200px" width="200px" style="background-color: transparent; vertical-align: middle; margin-top: 120px;" src="<%= Page.ResolveClientUrl("~/Assets/loading.gif") %>" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!-- End of Modal Add lasa -->

     <!-- ##### Modal Edit lasa ##### -->
    <div class="modal fade" id="modalEditLasa" role="dialog" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 50px;" data-keyboard="false">

        <div class="modal-dialog" style="width: 500px">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="return resetModalForm()">×</button>
                    <h4 class="modal-title">
                        <label>LASA MEDICATION LISTs</label>
                    </h4>
                </div>

                <!-- Modal body -->
                <div class="modal-body">

                    <!-- update panel ini berfungsi untuk menjaga item didalamnya tidak terrefresh oleh postback dari luar update panel ini -->
                    <asp:UpdatePanel ID="UpdatePanelEDITorg" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="HiddenTransactionID" runat="server" />
                            

                            <table class="table text-left" style="margin-top: -15px;">
                                <tr>
                                    <td style="width: 30%; border-width: 0;">Drug Name</td>
                                    <td style="border-width: 0;">:</td>
                                    <td style="border-width: 0;">
                                    <asp:Label ID="Label_drag_name_edit" runat="server" Text="">Label</asp:Label></td>
                                   
                                </tr>
                                <tr>
                                    <td style="border-width: 0;">Is Lasa?</td>
                                    <td style="border-width: 0;">:</td>
                                    <td style="border-width: 0;">
                                        <asp:RadioButtonList ID="Rb_is_lasa_edit"  runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                            <asp:ListItem ID="edit_yes_lasa" Text="Yes" Value="True"></asp:ListItem>
                                            <asp:ListItem ID="edit_no_lasa" Text="No" Value="False" Style="margin-left: 20px; font-weight: lighter"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 30%; border-width: 0;">Last Modified</td>
                                    <td style="border-width: 0;">:</td>
                                    <td style="border-width: 0;">
                                        <asp:Label ID="Label_last_modif" runat="server" Text="">Label</asp:Label></td>
                                </tr>
                            </table>

                            <!-- dipasangi update panel agar element didalamnya dapat diupdate dari server side dan tidak terrefresh oleh postback -->
                            <asp:UpdatePanel ID="UpdatePanelExistEdit" runat="server">
                                <ContentTemplate>
                                    <b>
                                        <p style="color: red; display: none" id="p_Edit" runat="server"></p>
                                    </b>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanelSAVEedit" runat="server">
                                <ContentTemplate>
                                    <div class="text-right">
                                        <asp:Button ID="Edit_ButtonSaveLasa" runat="server" Text="Save" ForeColor="White" class="btn btn-edit-lasa " OnClientClick="return EditFormCheck()" OnClick="Edit_ButtonSaveLasa_Click"></asp:Button>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <%--update progress yang berbentuk modal hanya untuk button save--%>
                            <asp:UpdateProgress ID="EdituProgSAVE" runat="server" AssociatedUpdatePanelID="UpdatePanelSAVEedit">
                                <ProgressTemplate>
                                    <div class="modal-backdrop" style="background-color: black; opacity: 0.4; text-align: center">
                                        <img alt="" height="200px" width="200px" style="background-color: transparent; vertical-align: middle; margin-top: 120px;" src="<%= Page.ResolveClientUrl("~/Assets/loading.gif") %>" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
