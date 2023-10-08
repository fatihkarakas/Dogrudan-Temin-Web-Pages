<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="mesajyaz.aspx.cs" Inherits="yonetim_mesajyaz" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server"></asp:ToolkitScriptManager>
 
      <section class="content-header">
        <h1>Mesaj Yaz </h1>
           
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i></a></li>

        </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <a href="mesajyaz.aspx" class="btn btn-primary btn-block margin-bottom">Mesaj Yaz</a>
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Klasörler</h3>
                        <div class='box-tools'>
                            <button class='btn btn-box-tool' data-widget='collapse'><i class='fa fa-minus'></i></button>
                        </div>
                    </div>
                    <div class="box-body no-padding">
                        <ul class="nav nav-pills nav-stacked">
                            <li class="active"><a href="mesajlar.aspx"><i class="fa fa-inbox"></i>Gelen Kutusu <span class="label label-primary pull-right"></span></a></li>
                            <li><a href="mesajyaz.aspx"><i class="fa fa-envelope-o"></i>Mesaj Yaz</a></li>
                            <li><a href="mesajgiden.aspx"><i class="fa fa-file-text-o"></i>Giden Kutusu</a></li>

                        </ul>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /. box -->

            </div>
            <!-- /.col -->
        
                       <div class="col-md-9">
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Yeni Mesaj Yaz</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                         <div class="col-md-12" id="div_bilgi" runat="server" visible="false">
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
                                                <asp:Label runat="server" ID="bilgiver"></asp:Label>
                                            </div>
                                            <!-- /.box-body -->
                                        </div>
                                        <!-- /.box -->
                                    </div>
                  <div class="form-group">
                      <label>Kime Gidecek</label>
                   <asp:DropDownList runat="server" ID="kime_text" CssClass="form-control"></asp:DropDownList><asp:Button runat="server" ID="kisi_ekle_btn" Text="Kişiyi Ekle" CssClass="btn btn-success" OnClick="kisi_ekle_btn_Click" />
                  </div>
                  <div class="form-group">
                   <label> Mesaj Gidecekler</label> <asp:ListBox runat="server" ID="kimlere_list" CssClass="form-control"></asp:ListBox>
                 <asp:Button runat="server" Text="Çıkart" ID="cikar" CssClass="btn btn-danger" OnClick="cikar_Click" />
                  </div>
                  <div class="form-group">
                    <label>Konu Başlığı</label>
                      <asp:TextBox runat="server" ID="konu" CssClass="form-control" PlaceHolder="Konu Başlığı Yazınız"></asp:TextBox>
                  </div>
                    <div class="form-group">
                    <label>Mesajınız: </label>
                       <cc1:Editor ID="mesaji" runat="server" />
                  </div>
                  <div class="form-group">
                    <div class="btn btn-default btn-file">
                      <i class="fa fa-paperclip"></i> Dosya Ekle
                     <asp:FileUpload runat="server" ID="dosya" CssClass="attachment" />
                    </div>
                  
                  </div>
                </div><!-- /.box-body -->
                <div class="box-footer">
                  <div class="pull-right">
                   
                    <asp:Button runat="server" ID="gonder" CssClass="btn btn-info" Text="Mesajımı Gönder" OnClick="Gonder_Click" />
                  </div>
                  
                </div><!-- /.box-footer -->
              </div><!-- /. box -->
            </div><!-- /.col -->
            </div>
           
           

       
        <!-- /.row -->
    </section>
    
          
</asp:Content>

