<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="beklemedekilerdetay.aspx.cs" Inherits="beklemedekilerdetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
        function onlyNumber(e) {
            var keyCode = event.keyCode;
            if ((keyCode < 46 || keyCode > 57) && keyCode != 8 && keyCode != 9 && keyCode != 0 && keyCode != 47 && (keyCode < 96 || keyCode > 105)) {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <section class="content-header">
          <h1>
            Beklemedeki Alım Dosya Detayı
          </h1>
           <asp:Label runat="server" ID="krm" CssClass="small right-side" Visible="false"></asp:Label>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Detaylara Gidip İşlemleri Tamamlayınız</a></li>
            <li class="active"></li>
          </ol>
        </section>

     <section class="content">
        <div class="row">

            <div class="col-md-12">

                 <div id='dialog-page' title="Modal" class="modal">
        
    </div>


                <asp:Repeater runat="server" ID="dtihale" OnItemCommand="dtihale_ItemCommand">
                    <ItemTemplate>
                        <div class="box box-solid">
                            <div class="box-header with-border">
                                <h3 class="box-title">Kurum: <%#Eval("kurum") %>     /     Alım Dosya Tarih: <%#Eval("tarih") %> </h3>
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
                                            <img src= '../images/<%# DataBinder.Eval(Container.DataItem, "onay") %>.png'  
 alt="Durum" height="25" width="25" />
                                        </td>
                                        <td><b>İhale Kodu:</b></td>
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
                                        <td><%#Eval("kontroltarih") %></td>
                                        <td><b>İşlem :</b></td>
                                        <td>
                                           
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="sil" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-danger" OnClientClick="return confirm('Dosyayı Tümüyle  Siliyorsunuz');">Dosyayı Sil</asp:LinkButton>
                                            <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="reddet" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-danger" OnClientClick="return confirm('Dosyayı Red Ediyorsunuz..?');">Reddet</asp:LinkButton>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td> <b>Açıklama Ekle :</b> </td>
                                        <td colspan="2">
                                          
                         
                            <asp:TextBox runat="server" ID="comment1" placeholder="Alım Dosyası Açıklama" TextMode="MultiLine" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem,"comment") %>'></asp:TextBox>
                                               
                     
                                            
                                        </td>
                                        <td> <asp:LinkButton ID="cmmtekle" runat="server" CommandName="aekle" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-success" >Açıklamayı Ekle</asp:LinkButton></td>
                                    </tr>

                                </table>

                            </div>
                            <!-- /.box-body -->
                            
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <div class="box box-solid">
                    
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

                                <div class="col-md-12">
                            <div class="box">

                                <div class="box-body">
                                    <div class="box-body table-responsive no-padding">
                                       
                                      <asp:Repeater ID="dogrudanlistesielle" runat="server" OnItemCommand="dogrudanlistesielle_ItemCommand">
                                            <HeaderTemplate>
                                                <table class="table table-hover">
                                                    <tr style="background-color:blue;color:white">
                                                        <td style="width:20px"></td>
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
                                                        <td class="auto-style2">Son Alım Barkodu</td>
                                                        <td>Açıklama</td>
                                                        <td class="auto-style2">İşlem</td>
                                                        <td>Sil</td>
                                                    </tr>
                                                    </HeaderTemplate>
                                             <ItemTemplate> 
                                                <tr>
                                                    <td><%# degisiklikvarmi(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"id"))) %> </td>
                                                       <td><img src= 'images/<%# DataBinder.Eval(Container.DataItem, "onay") %>.png'  
 alt="Durum" height="25" width="25" /></td>
                                                        <td><asp:TextBox runat="server" ID="st" Text='<%# DataBinder.Eval(Container.DataItem, "SUT")%>'></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="mh" Text='<%# DataBinder.Eval(Container.DataItem, "mal_hizmet_yapim")%>'></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="kb" Text='<%# DataBinder.Eval(Container.DataItem, "kanun_bend")%>'></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="cns" Text='<%# DataBinder.Eval(Container.DataItem, "cinsi")%>'></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="mkt" Text='<%# DataBinder.Eval(Container.DataItem, "miktar")%>'></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="brm" Text='<%# DataBinder.Eval(Container.DataItem, "birim")%>'></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="syt" Text='<%# DataBinder.Eval(Container.DataItem, "son_yil_tuketim")%>'></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="bsy" Text='<%# DataBinder.Eval(Container.DataItem, "birim_son_yil")%>'></asp:TextBox></td>
                                                    <td><asp:TextBox runat="server" ID="sf" Text='<%# DataBinder.Eval(Container.DataItem, "son_fiyat")%>'></asp:TextBox></td>
                                                    <td><asp:TextBox runat="server" ID="sabrkd" Text='<%# DataBinder.Eval(Container.DataItem, "son_alim_barkod")%>'></asp:TextBox></td>
                                                    <td><asp:TextBox runat="server" ID="aciklama" Text='<%# DataBinder.Eval(Container.DataItem, "aciklama")%>' Enabled="false"></asp:TextBox></td>
                                                        <td><asp:LinkButton ID="lnkEdit" runat="server" CommandName="duzelt" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-info">Düzelt</asp:LinkButton>
                                                            
                                                        </td>
                                                    <td>
                                                        <asp:LinkButton ID="lnksil" runat="server" CommandName="sil" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-danger">Sil</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                       <FooterTemplate>
                                           <tr>
                                               <td></td>
                                                     <td></td>
                                                        <td><asp:TextBox runat="server" ID="st2"></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="mh2" ></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="kb2"></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="cns2"></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" onkeydown="return onlyNumber(event)" ID="mkt2"></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="brm2"></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" onkeydown="return onlyNumber(event)" ID="syt2"></asp:TextBox></td>
                                                        <td><asp:TextBox runat="server" ID="bsy2"></asp:TextBox></td>
                                                    <td><asp:TextBox runat="server" onkeydown="return onlyNumber(event)" ID="sf2"></asp:TextBox></td>
                                                    <td><asp:TextBox runat="server" ID="sabrkd2"></asp:TextBox></td>
                                                        <td><asp:LinkButton ID="lnkEdit" runat="server" CommandName="ekle" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="btn btn-info">Ekle</asp:LinkButton>
                                                           
                                                            
                                                        </td>
                                                </tr>
                                           </table></FooterTemplate>
                                                
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
                <%--onaylanmışlat bitti--%>
            
            </div>

        </div>



    </section>
</asp:Content>

