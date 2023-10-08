<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="Dosya_Ac.aspx.cs" Inherits="Dosya_Ac"  ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 470px;
        }

        .auto-style2 {
            height: 37px;
        }

        .auto-style4 {
            height: 43px;
        }
    </style>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode == 44) {
                var inputValue = $("#inputfield").val()
                if (inputValue.indexOf(',') < 1) {
                    return true;
                }
                return false;
            }
            if (charCode != 44 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
        <h4>İhale Dosya Aç
            <asp:Label runat="server" ID="krm" CssClass="small right-side"></asp:Label>
            <asp:Label runat="server" ID="krmid" CssClass="small right-side" Visible="false"></asp:Label>
        </h4>

    </section>
    <section class="content">
        <asp:Panel runat="server" ID="pnl_snc" Visible="false">
            <div class="box">
                <div class="box-header with-border box box-primary">
                    <h3 class="box-title">SONUÇ</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Gizle/Göster"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Yoksay"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <label class="alert-success">İhale Dosyanız Başarı İle Açıldı.</label>

                    <div class="row">

                        <div class="col-md-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Alım Dosya Bilgileriniz</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="col-md-12" id="sartnamediv" runat="server" visible="false">
                                        <div class="box box-danger box-solid">
                                            <div class="box-header with-border">
                                                <h3 class="box-title">Bilgilendirme Mesajı !!!</h3>
                                                <div class="box-tools pull-right">
                                                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                </div>
                                                <!-- /.box-tools -->
                                            </div>
                                            <!-- /.box-header -->
                                            <div class="box-body">
                                                <asp:Label runat="server" ID="sartnamelabel"></asp:Label>
                                            </div>
                                            <!-- /.box-body -->
                                        </div>
                                        <!-- /.box -->
                                    </div>

                                    <table class="table table-bordered">
                                        <tr>
                                            <th style="width: 10px">ID</th>
                                            <th>Alım Kod</th>
                                            <th>Alım Dosya Adı</th>
                                            <th>Alım Açıklama</th>
                                            <th>Alım Liste Ekleme</th>
                                        </tr>
                                        <tr>
                                            <td class="auto-style4">
                                                <asp:Label runat="server" ID="iid"></asp:Label></td>
                                            <td class="auto-style4">
                                                <asp:Label runat="server" ID="ikod"></asp:Label></td>
                                            <td class="auto-style4">
                                                <asp:Label runat="server" ID="ia"></asp:Label></td>
                                            <td class="auto-style4">
                                                <asp:Label runat="server" ID="iac"></asp:Label></td>
                                            <td class="auto-style4">
                                                <asp:Button runat="server" ID="elleekle" Text="Elle ekle" CssClass="btn-info" OnClick="elleekle_Click" />
                                                <asp:Button runat="server" ID="excelekle" Text="Excel ekle" CssClass="btn-dropbox" OnClick="excelekle_Click" />

                                            </td>
                                        </tr>
                                        <% fonksiyonlar fs = new fonksiyonlar();
                                           sartnamaler.DataSource = fs.sartnameler(Convert.ToInt32(iid.Text));
                                           sartnamaler.DataBind();
                                        %>
                                    </table>
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Alım Dosyasına Şartname/Dosya Ekle</h3>
                                    </div>
                                    <table class="table table-hover">
                                        <tr>
                                            <th>Dosya Seç</th>
                                            <th>Dosya Adı </th>
                                            <th>Dosya Açıklama</th>
                                            <th>Dosya Tipi</th>
                                            <th></th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:FileUpload runat="server" ID="srtn_ekle" CssClass="filename" /></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="dosyadi" CssClass="form-control" PlaceHolder="Dosya Adı"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="dosyaaciklama" TextMode="MultiLine" CssClass="box-input"></asp:TextBox></td>
                                            <td>
                                                <asp:RadioButtonList runat="server" ID="dosyatip">
                                                    <asp:ListItem Selected="True">Şartname</asp:ListItem>
                                                    <asp:ListItem>Dosya</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                            <td>
                                                <asp:Button runat="server" ID="btn_srtn" Text="EKLE" CssClass="btn-dropbox" OnClick="btn_srtn_Click" /></td>
                                        </tr>

                                    </table>
                                    <asp:Repeater ID="sartnamaler" runat="server">
                                        <HeaderTemplate>
                                           <div class="box-header with-border">
                                        <h3 class="box-title">Eklenmiş Dosyalar</h3>
                                    </div>
                                            <table class="table table-bordered">
                                                <tr>
                                                    <th>Dosya Adı</th>
                                                    <th>Dosya Açıklama</th>
                                                    <th>Tip</th>
                                                    <th>İndir</th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><b><%#Eval("dosya_adi") %></b></td>
                                                <td><%# Eval("dosya_aciklama") %></td>
                                                <td><%# Eval("tipi") %> </td>
                                                <td><a href='<%#Eval("ihale_dosya") %>' class="btn btn-info">Dosyayı İndir</a></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- /.box-body -->

                            </div>
                            <!-- /.box -->


                        </div>

                    </div>
                </div>
                <!-- /.box-body -->

            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="ilk">
            <div class="box">
                <div class="box-header with-border box box-primary">
                    <h3 class="box-title">Yeni Alım Dosyası Ekle</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Gizle/Göster"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Yoksay"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="box-body">
                        <div class="col-md-12" id="sncdiv" runat="server" visible="false">
                            <div class="box box-danger box-solid">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Bilgilendirme Mesajı !!!</h3>
                                    <div class="box-tools pull-right">
                                        <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                    <!-- /.box-tools -->
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <asp:Label runat="server" ID="sncmsj"></asp:Label>
                                </div>
                                <!-- /.box-body -->
                            </div>
                            <!-- /.box -->
                        </div>
                        <asp:Label runat="server" ID="snc" CssClass="alert-error" Visible="false"></asp:Label>
                        <div class="form-group">
                            <label for="ihale_adi">Alım Dosya Adını Yazınız</label>
                            <asp:TextBox runat="server" ID="ihale_adi" placeholder="İhale Adı Giriniz" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="iaciklama">Alım Dosya Açıklaması </label>
                            <asp:TextBox runat="server" ID="iaciklama" placeholder="İhale Açıklama" ClientIDMode="Static" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="zihale_btn" Text="Alım Dosyası Aç" CssClass="btn btn-primary" OnClick="zihale_btn_Click" />

                        </div>

                    </div>
                </div>
                <!-- /.box-body -->
                <div class="box-footer primary">
                </div>
                <!-- /.box-footer-->
            </div>
            <!-- /.box -->
        </asp:Panel>

        <asp:Panel runat="server" ID="excelpanel" Visible="false">
            <div class="box">
                <div class="box-header with-border box box-primary">
                    <h3 class="box-title">Excel Dosyasından Veri Ekle</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Gizle/Göster"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Yoksay"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="box-body">
                        <asp:Label runat="server" ID="excelhata" CssClass="alert-error" Visible="false"></asp:Label>
                        <br />
                        <div id="sncdiv0" runat="server" class="col-md-12" visible="false">
                            <div class="box box-danger box-solid">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Bilgilendirme Mesajı !!!</h3>
                                    <div class="box-tools pull-right">
                                        <button class="btn btn-box-tool" data-widget="remove">
                                            <i class="fa fa-times"></i>
                                        </button>
                                    </div>
                                    <!-- /.box-tools -->
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <asp:Label ID="sncmsj0" runat="server"></asp:Label>
                                </div>
                                <!-- /.box-body -->
                            </div>
                            <!-- /.box -->
                        </div>
                        <div class="form-group">
                            <a href="dosyalar/DT.xls" class="btn-link">Doğrudan Temin Excel Dosyası</a>
                        </div>
                        <div class="form-group">
                            <label for="iaciklama">Yüklenecek Excel Dosyasını Seçiniz </label>
                            <asp:FileUpload runat="server" ID="excelcek" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="excelyuke" Text="Excel Dosyasını Oku" CssClass="btn btn-primary" OnClick="Button1_Click" />

                        </div>

                        <div runat="server" id="exceldiv" visible="false">
                            <asp:GridView ID="elemanexcel" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1" Width="90%">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                            <asp:Button runat="server" ID="ex_d_ekle" Text="Bu Verileri Alım Dosyasına Ekle" CssClass="btn btn-primary" OnClick="ex_d_ekle_Click" />
                        </div>

                    </div>
                </div>
                <!-- /.box-body -->
                <div class="box-footer primary">
                </div>
                <!-- /.box-footer-->
            </div>
            <!-- /.box -->
        </asp:Panel>

        <asp:Panel runat="server" ID="elleeklepnl" Visible="false">
            <div class="box">
                <div class="box-header with-border box box-primary">
                    <h3 class="box-title">Alım Dosyasına Elle Ekle</h3>
                    <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Gizle/Göster"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Yoksay"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="box">

                                <div class="box-body">
                                    <div class="box-body table-responsive no-padding">
                                        <asp:Label runat="server" ID="eklersonuc" CssClass="alert-error" Visible="false"></asp:Label><br />
                                        <div class="box-info">* Sut Kodu, Kanun Bendi, Türü gibi belgeleri doldurunuz.</div>
                                        <div class="info">* Hatalı girilen SUT kodlarından kullanıcı sorumlu tutulacaktır</div>
                                        <table class="table table-hover">
                                            <tr>
                                                <td class="auto-style1">SUT Kodu:</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="sutkodu" CssClass="form-control"></asp:TextBox></td>
                                                <td>Türü:</td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="tur" CssClass="form-control">
                                                        <asp:ListItem>Seçiniz</asp:ListItem>
                                                        <asp:ListItem>Mal alımı</asp:ListItem>
                                                        <asp:ListItem>Hizmet Alımı</asp:ListItem>
                                                        <asp:ListItem>Yapım İşleri</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style1">Kanun Bendi:</td>
                                                <td>
                                                    <asp:TextBox ID="kanuntext" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td>Cinsi :</td>
                                                <td>
                                                    <asp:TextBox ID="cinsitext" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Miktarı:</td>
                                                <td>
                                                    <asp:TextBox ID="miktartext" onkeydown="return onlyNumber(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td>Birimi</td>
                                                <td>
                                                    <asp:TextBox ID="birimitext" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">Son Yıl Tüketim:</td>
                                                <td>
                                                    <asp:TextBox ID="sonyiltext" onkeydown="return onlyNumber(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td>Birim Son Yıl:</td>
                                                <td>
                                                    <asp:TextBox ID="birimsonyiltext" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style1">Son Alım Fiyatı:</td>
                                                <td>
                                                    <asp:TextBox ID="sonalimfiyattext" onkeydown="return onlyNumber(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                                <td>Son Alım Barkodu:</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="sabarkod" CssClass="form-control"></asp:TextBox></td>

                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center">
                                                    <asp:Button runat="server" ID="elleekler" Text="Dosyaya Ekle" CssClass="btn-bitbucket" OnClick="elleekler_Click" /></td>
                                            </tr>

                                        </table>
                                        <br />

                                    </div>
                                </div>
                                <!-- /.box-body -->
                                <div class="box-footer clearfix">
                                </div>
                            </div>
                            <!-- /.box -->


                        </div>

                    </div>
                </div>
                <!-- /.box-body -->

            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="elemanlistesipaneli" Visible="false">
            <div class="box-body">

                <div class="row">

                    <div class="col-md-12">
                        <div class="box">

                            <div class="box-body">
                                <div class="box-body table-responsive no-padding">

                                    <asp:Repeater ID="dogrudanlistesielle" runat="server" OnItemCommand="dogrudanlistesielle_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-hover">
                                                <tr style="background-color: blue; color: white">
                                                    <td class="auto-style2">SUT Kodu</td>
                                                    <td class="auto-style2">Türü</td>
                                                    <td class="auto-style2">Kanun Bendi</td>
                                                    <td class="auto-style2">Cinsi</td>
                                                    <td class="auto-style2">Miktarı</td>
                                                    <td class="auto-style2">Birimi</td>
                                                    <td class="auto-style2">Son Yıl Tük.</td>
                                                    <td class="auto-style2">Birim Son Yıl</td>
                                                    <td class="auto-style2">Son Alım Fiyat</td>
                                                    <td class="auto-style2">Son Alım Barkod</td>
                                                    <td class="auto-style2">İşlem</td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>

                                                <td>
                                                    <asp:TextBox runat="server" ID="st" Text='<%# DataBinder.Eval(Container.DataItem, "SUT")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="mh" Text='<%# DataBinder.Eval(Container.DataItem, "mal_hizmet_yapim")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="kb" Text='<%# DataBinder.Eval(Container.DataItem, "kanun_bend")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="cns" Text='<%# DataBinder.Eval(Container.DataItem, "cinsi")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="mkt" Text='<%# DataBinder.Eval(Container.DataItem, "miktar")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="brm" Text='<%# DataBinder.Eval(Container.DataItem, "birim")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="syt" Text='<%# DataBinder.Eval(Container.DataItem, "son_yil_tuketim")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="bsy" Text='<%# DataBinder.Eval(Container.DataItem, "birim_son_yil")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="sf" Text='<%# DataBinder.Eval(Container.DataItem, "son_fiyat")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="sabrkd" Text='<%# DataBinder.Eval(Container.DataItem, "son_alim_barkod")%>'></asp:TextBox></td>
                                                <td>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="duzelt" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-info">Düzelt</asp:LinkButton>
                                                    <asp:LinkButton ID="lnksil" runat="server" CommandName="sil" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-danger">Sil</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>

                                                <td>
                                                    <asp:TextBox runat="server" ID="st2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="mh2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="kb2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="cns2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="mkt2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="brm2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="syt2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="bsy2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="sf2"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="sabrkd2"></asp:TextBox></td>
                                                <td>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="ekle" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-info">Ekle</asp:LinkButton>

                                                </td>
                                            </tr>
                                            </table>
                                        </FooterTemplate>

                                    </asp:Repeater>
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer clearfix">
                            </div>
                        </div>
                        <!-- /.box -->


                    </div>

                </div>
            </div>

        </asp:Panel>






    </section>
</asp:Content>

