<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giris.aspx.cs" Inherits="giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8" />
    <title>Sistem Girişi</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <!-- Bootstrap 3.3.4 -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Font Awesome Icons -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link href="plugins/iCheck/square/blue.css" rel="stylesheet" type="text/css" />
</head>
<body class="login-page">
    <form id="form1" runat="server">
   
    <div class="login-box">
      <div class="login-logo">
        <a href="#"><b>Ankara 3. Bölge Genel Sekreterliği</b></a>
      </div><!-- /.login-logo -->
      <div class="login-box-body">
          <asp:Label runat="server" ID="bilgi_ver" CssClass="alert alert-danger" Visible="false"></asp:Label>
        
        
          <div class="form-group has-feedback">
              <asp:TextBox runat="server" class="form-control" placeholder="Kullanıcı Adınız" ID="user" type="user" ></asp:TextBox>
            
            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
            <asp:TextBox runat="server" class="form-control" placeholder="Parola" ID="password" type="password" TextMode="Password" ></asp:TextBox>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="row">
            <div class="col-xs-8">    
              <div class="checkbox icheck">
                <label>
                  <asp:CheckBox runat="server" ID="hatirla" /> Beni Hatırla
                </label>
              </div>                        
            </div><!-- /.col -->
            <div class="col-xs-4">
                <asp:Button runat="server" ID="gonder" Text="Giriş Yap" CssClass="btn btn-primary btn-block btn-flat" OnClick="gonder_Click" />
              
            </div><!-- /.col -->
          </div>
    

      </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->

    <!-- jQuery 2.1.4 -->
    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <script>
      $(function () {
        $('input').iCheck({
          checkboxClass: 'icheckbox_square-blue',
          radioClass: 'iradio_square-blue',
          increaseArea: '20%' // optional
        });
      });
    </script>
    </form>
</body>
</html>
