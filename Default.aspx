<%@ Page Title="" Language="C#" MasterPageFile="~/tema.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 470px;
        }

        .auto-style2 {
            height: 37px;
        }

        .auto-style4 {
            height: 43px;
        }
    </style>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode == 44) {
                var inputValue = $("#inputfield").val()
                if (inputValue.indexOf(',') < 1) {
                    return true;
                }
                return false;
            }
            if (charCode != 44 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
          <h1>
            Bilgilendirme
            
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> AnaSayfa</a></li>
            <li class="active">Bilgilendirme</li>
          </ol>
        </section>
    <section class="content">
    <!-- Small boxes (Stat box) -->
          <div class="row">
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="toplamihale"></asp:Label></h3>
                  
                  <p>Kurum Tarafından Dosya Talebi </p>
                </div>
                <div class="icon">
                  <i class="fa fa-shopping-cart"></i>
                </div>
                <a href="TumDosyalarim.aspx" class="small-box-footer">
                  Detaylar <i class="fa fa-arrow-circle-right"></i>
                </a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="ihaleonayli"></asp:Label></h3>
                  <p>Onaylanmış Alım Dosyası / İşlem Bekliyor</p>
                </div>
                <div class="icon">
                  <i class="ion ion-stats-bars"></i>
                </div>
                <a href="onaylanmislar.aspx" class="small-box-footer">
                  Detaylar <i class="fa fa-arrow-circle-right"></i>
                </a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3><asp:Label runat="server" ID="ihaletamam"></asp:Label></h3>
                  <p>Tamamlanmış Alım Dosyaları</p>
                </div>
                <div class="icon">
                   <i class="fa fa-shopping-cart"></i>
                </div>
                <a href="onaylilar.aspx" class="small-box-footer">
                Detaylar <i class="fa fa-arrow-circle-right"></i>
                </a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3> <asp:Label runat="server" ID="ihalered"></asp:Label></h3>

                  <p>Red Edilen Alım Dosyası</p>
                </div>
                <div class="icon">
                  <i class="ion ion-pie-graph"></i>
                </div>
                <a href="RedEdilenler.aspx" class="small-box-footer">
                  Detaylar <i class="fa fa-arrow-circle-right"></i>
                </a>
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->
        <div class="row">
            
            <div class="col-md-3 col-sm-6 col-xs-12">
                <a href="mesajlar.aspx">
              <div class="info-box bg-aqua">
                 <span class="info-box-icon bg-aqua"><i class="fa fa-envelope-o"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text">Mesajlar</span>
                  <span class="info-box-number"><asp:label runat="server" ID="mesajsayi"></asp:label> Mesajınız var</span>
                  <div class="progress">
                    <div class="progress-bar" runat="server" id="pg"></div>
                  </div>
                  <span class="progress-description">
                    <span style="color:red">Okunmamış <% Response.Write(okunmamis); %> mesaj bulunmaktadır</span>
                  </span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box --></a>
            </div>

        </div><!-- /.row -->

     </section>

</asp:Content>

