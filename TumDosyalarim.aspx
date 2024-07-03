<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="TumDosyalarim.aspx.cs" Inherits="TumDosyalarim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
      <section class="content-header">
          <h1>
            Tüm Alım Dosyalarım
            
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Dosyalar</a></li>
            <li class="active">Alım Dosyalarım</li>
          </ol>
        </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
              <div class="box">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">ALIM DOSYALARINIZ</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                    <asp:Repeater runat="server" ID="bilgi">
                        <HeaderTemplate>
                  <table id="example1"  class="table table-bordered table-striped">
                    <thead>
                      <tr>
                        <th>İçerik</th>
                        <th>Açıklama</th>
                        <th>Tarih</th>
                        <th>Dosya/Durum</th>
                        <th>Detay</th>
                      </tr>
                    </thead>
                    <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                      <tr>
                        <td><%#Eval("icerik") %></td>
                        <td><%# Eval("aciklama") %></td>
                        <td><%#Eval("tarih") %></td>
                        <td><%#Eval("onay").ToString() == "a" ? DosyaDurumunuGetir(Convert.ToInt32(Eval("onay")), Convert.ToInt32(Eval("sonuc"))) : DosyaDurumunuGetir(Convert.ToInt32(Eval("onay")), Convert.ToInt32(Eval("sonuc")))  %></td>
                        <td><a href='tumdosyalardetay.aspx?id=<%#Eval("id") %>' class="btn btn-info">Detay</a></td>
                      </tr>

                        </ItemTemplate>
                      <FooterTemplate>
                      
                    </tbody>
                    <tfoot>
                      <tr>
                        <th>İçerik</th>
                        <th>Açıklama</th>
                        <th>Tarih</th>
                        <th>Dosya/Durum</th>
                        <th>Detay</th>
                      </tr>
                    </tfoot>
                  </table></FooterTemplate>
                        </asp:Repeater>
                </div><!-- /.box-body -->
              </div>
                <!-- /.box-body -->
              </div><!-- /.box -->

            </div><!-- /.col -->
          </div>
          
    </section>

   <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- DATA TABES SCRIPT -->
    <script src="plugins/datatables/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="plugins/datatables/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <!-- SlimScroll -->
    <script src="plugins/slimScroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <!-- FastClick -->
    <script src='plugins/fastclick/fastclick.min.js'></script>
    <!-- AdminLTE App -->
    <script src="dist/js/app.min.js" type="text/javascript"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="dist/js/demo.js" type="text/javascript"></script>
    <!-- page script -->
    <script type="text/javascript">
        $("#example1").dataTable({

            "oLanguage": {
                "sLengthMenu": "_MENU_ Kayıt Göster",
                "sZeroRecords": "Eşleşen Kayıt Bulunmadı",
                "sInfo": "Gösterilen _START_ - _END_ / _TOTAL_",
                "sInfoEmpty": "Kayıt Yok",
                "sInfoFiltered": "( _MAX_ Kayıt İçerisinden Bulunan)",
                "sInfoPostFix": "",
                "sSearch": "Ara:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "İlk",
                    "sPrevious": "Önceki",
                    "sNext": "Sonraki",
                    "sLast": "Son"
                }
            },

        });
    </script>
</asp:Content>

