<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadAvatar.aspx.cs" Inherits="SPKTWeb.Profiles.UploadAvatar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-type" content="text/html; charset=utf-8" />
	<meta http-equiv="Content-Language" content="en-us" />
	<title>Test</title>
	<script src="../js/cropper/lib/prototype.js" type="text/javascript"></script>	
 	<script src="../js/cropper/lib/scriptaculous.js?load=builder,dragdrop" type="text/javascript"></script>
	<script src="../js/cropper/cropper.js" type="text/javascript"></script>
	
	
	<script type="text/javascript" charset="utf-8">

	    function onEndCrop(coords, dimensions) {
	        $('x1').value = coords.x1;
	        $('y1').value = coords.y1;
	        $('x2').value = coords.x2;
	        $('y2').value = coords.y2;
	        $('width').value = dimensions.width;
	        $('height').value = dimensions.height;
	    }

	    // example with a preview of crop results, must have minimumm dimensions
	    Event.observe(
			window,
			'load',
			function () {
			    new Cropper.ImgWithPreview(
					'testImage',
					{
					    minWidth: 200,
					    minHeight: 120,
					    ratioDim: { x: 500, y: 350 },
					    displayOnInit: true,
					    onEndCrop: onEndCrop,
					    previewWrap: 'previewArea'
					}
				)
			}
		);

    </script>
	<link rel="stylesheet" type="text/css" href="debug.css" media="all" />
	<style type="text/css">
		label { 
			clear: left;
			margin-left: 50px;
			float: left;
			width: 5em;
		}
		
		#testWrap {
			width: 500px;
			float: left;
			margin: 20px 0 0 50px; /* Just while testing, to make sure we return the correct positions for the image & not the window */
		}
		
		#previewArea {
			margin: 20px; 0 0 20px;
			float: left;
		}
		
		#results {
			clear: both;
		}
		
		.button
		{
		    margin: 20px; 0 0 20px;
			float: left;
		}  

	</style>
</head>
<body>	
	<form id="form1" runat="server">
    <div>
	<br /><asp:FileUpload ID="fuAvatarUpload" runat="server" />&nbsp;&nbsp;&nbsp;
      
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" 
                        Text="OK" />
                <br />
    </div>
	<asp:Panel ID="pnlUpload" Visible="true" runat="server">
	<div id="testWrap">
		<img src="~/Image/ProfileAvatar.aspx" alt="test image" id="testImage" width="500" height="350" runat="server" />
	</div>
    </asp:Panel>
	 
	<div id="previewArea">

     </div>
	<div class="button">
        <asp:Button ID="btnOK" runat="server" Text="Lấy hình này" 
            OnClick="btnOK_Click" />
                       
   </div>
	<div id="results" style="visibility:hidden">
		<p>
			<label for="x1">x1:</label>
			<input type="text" name="x1" id="x1" runat="server" clientidmode="Static" />
		</p>
		<p>
			<label for="y1">y1:</label>
			<input type="text" name="y1" id="y1" runat="server" clientidmode="Static"  />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		</p>
		<p>
			<label for="x2">x2:</label>
			<input type="text" name="x2" id="x2" runat="server" clientidmode="Static"  />
		</p>
		<p>
			<label for="y2">y2:</label>
			<input type="text" name="y2" id="y2" runat="server" clientidmode="Static" />
		</p>
		<p>
			<label for="width">width:</label>
			<input type="text" name="width" id="width" runat="server" clientidmode="Static" />
		</p>
		<p>
			<label for="height">height</label>
			<input type="text" name="height" id="height" runat="server" clientidmode="Static"  />
		</p>
	</div> 
	
    </form>
	
</body>
</html>
