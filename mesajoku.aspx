<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="mesajoku.aspx.cs" Inherits="yonetim_mesajoku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <section class="content-header">
        <h1>Gelen Mesajlar
           
            <small>13 Yeni Mesaj</small>
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
                            <li class="active"><a href="mesajlar.aspx"><i class="fa fa-inbox"></i>Gelen Kutusu <span class="label label-primary pull-right">12</span></a></li>
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
                 
                </div><!-- /.box-header -->
                <div class="box-body no-padding">
                  <div class="mailbox-read-info">
                    <h3><%Response.Write(baslik); %></h3>
                    <h5>Kimden: <%Response.Write(kimden); %> <span class="mailbox-read-time pull-right"> <%Response.Write(tarih); %></span></h5>
                  </div><!-- /.mailbox-read-info -->
                  <div class="mailbox-controls with-border text-center">
                    
                   
                  </div><!-- /.mailbox-controls -->
                  <div class="mailbox-read-message">
                    <%Response.Write(mesaj); %>
                  </div><!-- /.mailbox-read-message -->
                </div><!-- /.box-body -->
                <div class="box-footer"> <% if (dosya_var){ %>
                  <ul class="mailbox-attachments clearfix">
                    <li>
                      <span class="mailbox-attachment-icon"><i class="fa fa-file-pdf-o"></i></span>
                       
                      <div class="mailbox-attachment-info">
                        <a href='<%Response.Write(dosya); %>' class="mailbox-attachment-name"><i class="fa fa-paperclip"></i>Mail Eki</a>
                      
                      </div>
                       
                    </li>
                  
                  </ul> <% } %>
                </div><!-- /.box-footer -->
                <div class="box-footer">
                 
                </div><!-- /.box-footer -->
              </div><!-- /. box -->
            </div>

        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->


</asp:Content>

