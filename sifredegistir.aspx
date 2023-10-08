<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="sifredegistir.aspx.cs" Inherits="sifredegistir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="content-header">
        <h1>Şifre Değiştirme Ekranı </h1>
        <asp:Label ID="krm" runat="server" CssClass="small right-side" Visible="false"></asp:Label>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Detaylara Gidip İşlemleri Tamamlayınız</a></li>
            <li class="active"></li>
        </ol>
    </section>
     <section class="content">
              <div class="row">
               <div class="box-body no-padding">

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

                                <table class="table table-hover" style="align-content:center; width:50%; padding-left:100px; margin-left:100px;">
                                    <tr>
                                        <td style="width:35%; vertical-align:middle"> TC Kimlik Numarasnız:</td>
                                        <td> <asp:TextBox runat="server" ID="tck" PlaceHolder="TC Kimlik Numarası" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width:35%; vertical-align:middle">Yeni Parola</td>
                                        <td> <asp:TextBox runat="server" ID="parola" PlaceHolder="Parola" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width:35%; vertical-align:middle">Yeni Parola Tekrar</td>
                                        <td> <asp:TextBox runat="server" ID="parolat" PlaceHolder="Parola Tekrar" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="vertical-align:middle; text-align:center">
                                            <asp:Button runat="server" ID="pdegistir" Text="Parolamı Değiştir" CssClass="btn btn-info" OnClick="pdegistir_Click" />
                                        </td>
                                    </tr>
                                  </table>
                   </div>
            <div class="col-md-12">
                </div>
                  </div>
         </section>
</asp:Content>

