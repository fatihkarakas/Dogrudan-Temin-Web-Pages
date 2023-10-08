<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="mesajlar.aspx.cs" Inherits="yonetim_mesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Gelen Mesajlar
           
            <small><% Response.Write(okunmamis); %> Okunmamış Mesaj</small>
        </h1>
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
                            <li class="active"><a href="mesajlar.aspx"><i class="fa fa-inbox"></i>Gelen Kutusu <span class="label label-primary pull-right"><% Response.Write(mesajsayi); %></span></a></li>
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
                        <h3 class="box-title">Gelen Kutusu</h3>
                        <div class="box-tools pull-right">
                            <%--<div class="has-feedback">
                                <input type="text" class="form-control input-sm" placeholder="Search Mail" />
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            </div>--%>
                        </div>
                        <!-- /.box-tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <div class="mailbox-controls">
                            <!-- Check all button -->
                          <%--  <button class="btn btn-default btn-sm checkbox-toggle"><i class="fa fa-square-o"></i></button>
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm"><i class="fa fa-trash-o"></i></button>
                                <button class="btn btn-default btn-sm"><i class="fa fa-reply"></i></button>
                                <button class="btn btn-default btn-sm"><i class="fa fa-share"></i></button>
                            </div>
                            <!-- /.btn-group -->
                            <button class="btn btn-default btn-sm"><i class="fa fa-refresh"></i></button>--%>
                            <div class="pull-right">
                               
                     
                              <%--  <div class="btn-group">
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-left"></i></button>
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-right"></i></button>
                                </div>--%>
                                <!-- /.btn-group -->
                            </div>
                            <!-- /.pull-right -->
                        </div> 
                        <div class="table-responsive mailbox-messages">
                           
                         <table id="dene"  class="table table-bordered table-striped">
                        <asp:Repeater runat="server" ID="gelenmesalar">
                            <HeaderTemplate>
                           
                                
                                  
                                        <tbody>
                                            <tr>
                                                <th>Okundu</th>
                                                <th>Kimden</th>
                                                <th>Mesaj Konusu</th>
                                                <th>Dosya Eki</th>
                                                <th>Tarih</th>
                                            </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    
                                    <td class="mailbox-star"><img src='../<%# Eval("okundu") %>' /></td>
                                    <td class="mailbox-name"><a href="mesajoku.aspx?id=<%# Eval("mid") %>"><%# Eval("kimdenisim") %></a></td>
                                    <td class="mailbox-subject"><b><%# Eval("konu") %></b> ...</td>
                                    <td class="mailbox-attachment">  <img src='../<%# Eval("dosyaurl") %>' /></td>
                                    <td class="mailbox-date"><%# Eval("tarih") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                   
                                
                            </FooterTemplate>
                        </asp:Repeater> 

                             </table><!-- /.table -->
                                </div>
</div><!-- /.mail-box-messages -->
              
                    <!-- /.box-body -->
                    <div class="box-footer no-padding">
                        <div class="mailbox-controls">
                            <!-- Check all button -->
                            <%--<button class="btn btn-default btn-sm checkbox-toggle"><i class="fa fa-square-o"></i></button>--%>
                            <%--<div class="btn-group">
                                <button class="btn btn-default btn-sm"><i class="fa fa-trash-o"></i></button>
                                <button class="btn btn-default btn-sm"><i class="fa fa-reply"></i></button>
                                <button class="btn btn-default btn-sm"><i class="fa fa-share"></i></button>
                            </div>--%>
                            <!-- /.btn-group -->
                           <%-- <button class="btn btn-default btn-sm"><i class="fa fa-refresh"></i></button>
                            <div class="pull-right">
                                1-50/200
                     
                                <div class="btn-group">
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-left"></i></button>
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-right"></i></button>
                                </div>
                                <!-- /.btn-group -->
                            </div>--%>
                            <!-- /.pull-right -->
                        </div>
                    </div>
                </div>
                <!-- /. box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
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
        $("#dene").dataTable({

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

