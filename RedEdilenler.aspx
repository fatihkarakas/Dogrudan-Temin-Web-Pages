<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="RedEdilenler.aspx.cs" Inherits="RedEdilenler" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section class="content-header">
          <h1>
            Red Edilen Alım Dosyaları
          </h1>
           <asp:Label runat="server" ID="krm" CssClass="small right-side" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="krmid" CssClass="small right-side" Visible="false"></asp:Label>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Detaylara Gidip İşlemleri Tamamlayınız</a></li>
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
                                <h3 class="box-title"><b>Kurum: <%#Eval("kurum") %> </b>    /     İhale Tarih: <%#Eval("tarih") %> </h3>
                                <div class='box-tools'>
                                    <button class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button>
                                </div>
                            </div>
                            <div class="box-body no-padding">

                                <table class="table table-hover">
                                    <tr>
                                        <td style="width:25%; color:cadetblue"><b>Alım Dosyası Başlığı :</b></td>
                                        <td style="width:40%"><%#Eval("icerik") %></td>
                                        <td style="width:10%; color:cadetblue"><b>Dosya Kodu:</b></td>
                                        <td style="width:25%"><%#Eval("ihalekod") %></td>
                                    </tr>
                                  
                                    <tr>
                                        <td style="width:25%; color:cadetblue"><b>Açıklama :</b></td>
                                        <td colspan="2"><%#Eval("aciklama") %></td>
                                        <td><a href='reddetay.aspx?id=<%#Eval("id")%>' class="btn btn-success">Alım Dosya Detayı</a>
                                           </td>
                                    </tr>
                                  
                                </table>

                            </div>
                            <!-- /.box-body -->
                        </div>
                </ItemTemplate>
                </asp:Repeater>
                        </div>
                  
            </div>
        </section>
</asp:Content>

