<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="tamamlanmislar.aspx.cs" Inherits="tamamlanmislar"  ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="content-header">
        <h1>TAMAMLANMIŞ DOSYALAR
           
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


                <asp:Repeater runat="server" ID="dtihale">
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
                                            <img src='../images/<%# DataBinder.Eval(Container.DataItem, "onay") %>.png'
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
                                        <td>
                                            Durum : <img src='../images/<%# DataBinder.Eval(Container.DataItem, "Sonuc") %>.png'
                                                alt="Durum" height="20" width="20" />
                                        </td>
                                    </tr>

                                </table>

                            </div>
                            <!-- /.box-body -->

                        </div>
                    </ItemTemplate>
                </asp:Repeater>

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
                   <%--onaylanmamışlar başla--%>
                <div class="box-body">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="box">

                                <div class="box-body">
                                    <div class="box-body table-responsive no-padding">
                            
                                       <asp:Repeater ID="elemanlar" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table table-hover">
                                                                <tr style="background-color: blue; color: white">
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
                                                                    <td class="auto-style2">Teklif Edilen Marka</td>
                                                                    <td class="auto-style2">Barkod</td>
                                                                    <td class="auto-style2">Birim Fiyat</td>
                                                                    <td class="auto-style2">Tedarikçi</td>
                                                                    <td class="auto-style2">Açıklama</td>
                                                                   
                                                                    
                                                                </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <img src='../images/<%# DataBinder.Eval(Container.DataItem, "onay") %>.png'
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
                                                                <td><%#Eval("teklif_edilen_marka") %></td>
                                                                <td><%#Eval("barkod_kod") %></td>
                                                                <td><%#Eval("birim_fiyat") %></td>
                                                                <td><%#Eval("tedarikci") %> </td>
                                                                <td><%#Eval("aciklama") %> </td>
                                                               
                                                               
                                                              
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

