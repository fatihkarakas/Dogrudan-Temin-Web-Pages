<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="onaylamisdetay.aspx.cs" Inherits="onaylamisdetay" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function onlyNumber(e) {
            var keyCode = event.keyCode;
            if ((keyCode < 46 || keyCode > 57) && keyCode != 8 && keyCode != 9 && keyCode != 0 && keyCode != 47 && (keyCode < 96 || keyCode > 105)) {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Onaylanmış Alım Dosyaları
           
            <small></small>
        </h1>
        <asp:Label runat="server" ID="krm" CssClass="small right-side" Visible="false"></asp:Label>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Detaylara Gidip İşlemleri Tamamlayınız</a></li>
            <li class="active"></li>
        </ol>
    </section>

    <section class="content">
        <div class="row">

            <div class="col-md-12">


                <asp:Repeater runat="server" ID="dtihale" OnItemCommand="dtihale_ItemCommand">
                    <ItemTemplate>
                        <div class="box box-solid">
                            <div class="box-header with-border">
                                <h3 class="box-title">Kurum: <%#Eval("kurum") %>     /     Alım  Dosyası Tarih: <%#Eval("tarih") %> </h3>
                                <div class='box-tools'>
                                    <button class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button>
                                </div>
                            </div>
                            <div class="box-body no-padding">

                                <table class="table table-hover">
                                    <tr>
                                        <td><b>Alım Dosya Durumu :</b></td>
                                        <td>
                                            <%# Eval("onay").ToString() == "0" ? "Değerlendirilmemiş" : durumu(Eval("onay").ToString()) %>
                                            <img src='images/<%# DataBinder.Eval(Container.DataItem, "onay") %>.png'
                                                alt="Durum" height="20" width="20" />
                                        </td>
                                        <td><b>Dosya Kodu:</b></td>
                                        <td><%#Eval("ihalekod") %></td>
                                    </tr>
                                    <tr>
                                        <td><b>Başlık :</b></td>
                                        <td colspan="3"><%#Eval("icerik") %></td>
                                    </tr>
                                    <tr>
                                        <td><b>Açıklama :</b></td>
                                        <td colspan="3"><%#Eval("aciklama") %></td>
                                    </tr>
                                    <tr>
                                        <td><b>Okunma Tarihi :</b></td>
                                        <td colspan="2"><%#Eval("kontroltarih") %></td>
                                        <td><%if (kt(sayfaid) == true)
                                              { 
                                              
                                        %>
                                            <asp:LinkButton runat="server" ID="xok" CssClass="btn btn-success" CommandName="tamamla" CommandArgument='<%#DataBinder.Eval(Container,"id") %>'>Dosyayı Tamamla</asp:LinkButton>

                                            <%} %>
                                            Durum :
                                            <img src='images/<%# DataBinder.Eval(Container.DataItem, "Sonuc") %>.png'
                                                alt="Durum" height="20" width="20" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td> <b>Açıklama Ekle :</b> </td>
                                        <td colspan="2">
                                          
                         
                            <asp:TextBox runat="server" ID="comment1" placeholder="Alım Dosyası Açıklama" TextMode="MultiLine" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem,"comment") %>'></asp:TextBox>
                                               
                     
                                            
                                        </td>
                                        <td> <asp:LinkButton ID="cmmtekle" runat="server" CommandName="aekle" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-success" >Açıklamayı Ekle</asp:LinkButton></td>
                                        </td>

                                    </tr>
                                   
                                   

                                </table>

                            </div>
                            <!-- /.box-body -->

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                  <!-- /.Açılamalar -->
               
                    <asp:Repeater ID="aciklamalar" runat="server">
                                        <HeaderTemplate>
                                           <div class="box box box-solid">
                          <div class="box-header with-border">
                               <b><h5>Dosya Açıklamaları</h5></b>
                                <div class='box-tools'>
                                    <button class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button>
                                </div>
                            </div>
                       
                            <div class="box-body no-padding">
                                            <table class="table table-bordered">
                                                <tr>
                                                    <th style="width:60%">Bildirim Mesajı</th>
                                                    <th style="width:20%">Ekleyen</th>
                                                    <th style="width:20%">Ekleme Tarihi</th>
                                                   
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <tr>
                                                <td><%#Eval("aciklama") %></td>
                                                <td><%# Eval("ekleyen") %></td>
                                                <td><%# Eval("tarih") %> </td>
                                                </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                             </div>
                                               </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                    <!-- /.Açılamalar Bitti-->
               
                 
                    <!-- /.Dosya Ekleme -->
                    <div class="box box-solid">
                        
                            <div class="box-header with-border">
                               <h5>Alım Dosyasına Şartname Ekle</h5>
                                <div class='box-tools'>
                                    <button class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button>
                                </div>
                            </div>
                            <div class="box-body no-padding">
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
                                </div>
                         </div> 
                    <!-- /.Dosya Ekleme Bitti -->              
                     <!-- /.Şartnameler -->          
                    <asp:Repeater ID="sartnamerepeat" runat="server">
                                         <HeaderTemplate>
                                           <div class="box box box-solid">
                          <div class="box-header with-border">
                               <b><h5>Alım İçin Eklenen Dosyalar</h5></b>
                                <div class='box-tools'>
                                    <button class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button>
                                </div>
                            </div>
                       
                            <div class="box-body no-padding">
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
                                            </div>
                                            </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                 <!-- /.Şartamaler Bitti -->

                <%--onaylanmamışlar başla--%>
                <div class="box-body">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="box">

                                <div class="box-body">
                                    <div class="box-body table-responsive no-padding">

                                        <div class="col-md-12" id="sncdiv" runat="server" visible="false">
              <div class="box box-danger box-solid">
                <div class="box-header with-border">
                  <h3 class="box-title">Bilgilendirme Mesajı !!!</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div><!-- /.box-tools -->
                </div><!-- /.box-header -->
                <div class="box-body">
                  <asp:Label runat="server" ID="sncmsj"></asp:Label>
                </div><!-- /.box-body -->
              </div><!-- /.box -->
            </div>
                                        <br />

                                        İşlem Yapılacak Elemanlar
                                                    <asp:Repeater ID="dogrudanlistesielle" runat="server" OnItemCommand="dogrudanlistesielle_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table class="table table-hover">
                                                                <tr style="background-color: blue; color: white">
                                                                    <td></td>
                                                                    <td style="width=28px">Durumu</td>
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
                                                                    <td>Açıklama</td>
                                                                    <td class="auto-style2">Teklif Edilen Marka</td>
                                                                    <td class="auto-style2">Barkod</td>
                                                                    <td class="auto-style2">Birim Fiyat</td>
                                                                    <td class="auto-style2">Tedarikçi</td>
                                                                    <td class="auto-style2">Ekle</td>
                                                                    <td>Sil</td>

                                                                </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td><%# degisiklikvarmi(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"id"))) %> </td>
                                                                <td>
                                                                    <img src='images/<%# DataBinder.Eval(Container.DataItem, "onay") %>.png'
                                                                        alt="Durum" height="20" width="20" /></td>

                                                                <td><%#Eval("SUT") %></td>
                                                                <td><%#Eval("mal_hizmet_yapim") %></td>
                                                                <td><%#Eval("kanun_bend") %></td>
                                                                <td><%#Eval("cinsi") %></td>
                                                                <td><%#Eval("miktar") %></td>
                                                                <td><%#Eval("birim") %></td>
                                                                <td><%#Eval("son_yil_tuketim") %></td>
                                                                <td><%#Eval("birim_son_yil") %></td>
                                                                <td><%#Eval("son_fiyat") %></td>
                                                                <td><%#Eval("son_alim_barkod") %></td>
                                                                <td><%#Eval("aciklama") %></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="tem" Text='<%# DataBinder.Eval(Container.DataItem, "teklif_edilen_marka") %>'></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="brkd" Text='<%# DataBinder.Eval(Container.DataItem, "barkod_kod") %>'></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox runat="server"  ID="brfyt" Text='<%# DataBinder.Eval(Container.DataItem, "birim_fiyat") %>'></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="tdrk" Text='<%# DataBinder.Eval(Container.DataItem, "tedarikci") %>'></asp:TextBox></td>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="ekle" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-info">Tamamla</asp:LinkButton>
                                                                    
                                                                </td>
                                                                <td>  <asp:LinkButton ID="lnksil" CssClass="btn btn-danger" runat="server" CommandName="silmek" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'>Sil</asp:LinkButton></td>


                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
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
                <%--onaylanmışlat bitti--%>
            </div>

        </div>



    </section>
</asp:Content>

