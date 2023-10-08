<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="mesajgiden.aspx.cs" Inherits="yonetim_mesajgiden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="content-header">
        <h1>Giden Mesajlar
           
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
                            <li class="active"><a href="mesajlar.aspx"><i class="fa fa-inbox"></i>Gelen Kutusu <span class="label label-primary pull-right"><span class="label label-primary pull-right"><% Response.Write(mesajsayi); %></span></span></a></li>
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
                        <h3 class="box-title">Giden Kutusu</h3>
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
                        <asp:Repeater runat="server" ID="gelenmesalar">
                            <HeaderTemplate>
                                <div class="table-responsive mailbox-messages">
                                    <table class="table table-hover table-striped">
                                        <tbody>
                                            <tr>
                                                
                                                <th>Kimlere </th>
                                                <th>Mesaj Konusu</th>
                                                <th>Dosya Eki</th>
                                                <th>Tarih</th>
                                            </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    
                                    
                                    <td class="mailbox-name"><a href="gidenmesajoku.aspx?id=<%# Eval("mgid") %>"><%# Eval("kime_isimler") %></a></td>
                                    <td class="mailbox-subject"><b><%# Eval("konu") %></b> ...</td>
                                    <td class="mailbox-attachment">  <img src='<%# Eval("dosyaurl") %>' /></td>
                                    <td class="mailbox-date"><%# Eval("tarih") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                    </table><!-- /.table -->
                                </div><!-- /.mail-box-messages -->
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
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
</asp:Content>

