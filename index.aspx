<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta http-equiv="content-type" content="text/html; charset=UTF-8">
	<meta charset="utf-8">
	<title>Epilepsy Visualisation Tool</title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=no">
	<meta name="description" content="A visualisation of a patient's epileptic history.">
	<meta name="author" content="Esther Lim, Aleks Bulovic, Miguel Sanchez, Vincent Guerandel">
	<!-- STYLESHEETS --><!--[if lt IE 9]><script src="js/flot/excanvas.min.js"></script><script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script><script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script><![endif]-->
	<link rel="stylesheet" type="text/css" href="css/cloud-admin.css" >
	<link rel="stylesheet" type="text/css"  href="css/themes/graphite.css" id="skin-switcher" >
	<link rel="stylesheet" type="text/css"  href="css/responsive.css" >
	
	<link href="font-awesome/css/font-awesome.min.css" rel="stylesheet">
	<!-- DATE RANGE PICKER -->
	<link rel="stylesheet" type="text/css" href="js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
	<!-- FONTS -->
	<link href='http://fonts.googleapis.com/css?family=Oxygen' rel='stylesheet' type='text/css'>
    <link href="css/jasny-bootstrap.min.css" rel="stylesheet" media="screen">
</head>
<body>
	<!-- HEADER -->
	<header class="navbar clearfix" id="header">
		<div class="container">
				<div class="navbar-brand">
					<!-- COMPANY LOGO -->
					<a href="index.aspx">
						<img src="img/logo/logo.png" alt="Epilepsy Visualisation Tool Logo" class="img-responsive" height="50" width="200"> 
					</a>
					<!-- /COMPANY LOGO -->
				</div>
		</div>
	</header>
	<!--/HEADER -->
	
    <section id="page">
		<div id="main-content">

			<div class="container">
				<div class="row">
					<div id="content" class="col-lg-12">
						<!-- PAGE HEADER-->
						<div class="row">
							<div class="col-sm-12">
								<div class="page-header">

									<!-- BREADCRUMBS -->
									<ul class="breadcrumb">
									</ul>
									<!-- /BREADCRUMBS -->
									<div class="clearfix">
										<h2 class="content-title pull-left">Epilepsy Visualisation Tool</h2>
									</div>
									<div class="description">Visualisation of a patient's epilepsy history</div>
								</div>
							</div>
						</div>
						<!-- /PAGE HEADER -->


						<!-- INTERACTIVE CHART -->
						<div class="row">
							<div class="col-md-12">
								<div class="box border blue">
									<div class="box-title">
										<h4><i class="fa fa-signal"></i>Data visualisation chart</h4>

									</div>
									<div class="box-body">
										<div id="chart_2" class="chart"></div>
									</div>
								</div>
							</div>
						</div>
						<!-- /INTERACTIVE CHART -->

						<!-- BUTTON -->
                    <div>
                    <h4>Select a file to upload:</h4>

                       <asp:FileUpload id="FileUpload1"                 
                           runat="server">
                       </asp:FileUpload>

                       <br/><br/>

                       <asp:Button id="UploadButton" 
                           Text="Upload file"
                           OnClick="Upload"
                           runat="server">
                       </asp:Button>    

                       <hr />

                       <asp:Label id="UploadStatusLabel"
                           runat="server">
                       </asp:Label>  
        
                        <asp:Label ID="shout" runat="server"></asp:Label>  
                    </div>
                        <!-- /BUTTON -->
					</div>
				</div>
			</div>
		</div>
	</section>
	<!--/PAGE -->

	<!-- JAVASCRIPTS -->
	<!-- JQUERY -->
	<script src="js/flot/jquery.min.js"></script>
	<!-- JQUERY UI-->
	<script src="js/jquery-ui-1.10.3.custom/js/jquery-ui-1.10.3.custom.min.js"></script>
	<!-- BOOTSTRAP -->
	<script src="bootstrap-dist/js/bootstrap.min.js"></script>
	<!-- SLIMSCROLL -->
	<script type="text/javascript" src="js/jQuery-slimScroll-1.3.0/jquery.slimscroll.min.js"></script><script type="text/javascript" src="js/jQuery-slimScroll-1.3.0/slimScrollHorizontal.min.js"></script>
	<!-- BLOCK UI -->
	<script type="text/javascript" src="js/jQuery-BlockUI/jquery.blockUI.min.js"></script>
	<!-- FLOT CHARTS -->
	<script src="js/flot/jquery.flot.min.js"></script>
	<script src="js/flot/jquery.flot.time.min.js"></script>
    <script src="js/flot/jquery.flot.selection.min.js"></script>
	<script src="js/flot/jquery.flot.resize.min.js"></script>
    <script src="js/flot/jquery.flot.pie.min.js"></script>
    <script src="js/flot/jquery.flot.stack.min.js"></script>
    <script src="js/flot/jquery.flot.crosshair.min.js"></script>
	<!-- COOKIE -->
	<script type="text/javascript" src="js/jQuery-Cookie/jquery.cookie.min.js"></script>
    <!-- JASNY BOOTSTRAP -->
    <script src="js/jasny-bootstrap.min.js"></script>
	<!-- CUSTOM SCRIPT -->
	<script src="js/script.js"></script>
	<script>
	    
        jQuery(document).ready(function() {		
            App.setPage("flot_charts");  //Set current page
            App.init(); //Initialise plugins and elements
            Charts.initCharts();
        });


	    var Charts = function () {

	        return {
	            initCharts: function () {

	                if (!jQuery.plot) {
	                    return;
	                }

	                var data = [];
	                var maximum = 300;
	                function getRandomData() {
	                    if (data.length) {
	                        data = data.slice(1);
	                    }
	                    while (data.length < maximum) {
	                        var previous = data.length ? data[data.length - 1] : 50;
	                        var y = previous + Math.random() * 10 - 5;
	                        data.push(y < 0 ? 0 : y > 100 ? 100 : y);
	                    }
	                    // zip the generated y values with the x values
	                    var res = [];
	                    for (var i = 0; i < data.length; ++i) {
	                        res.push([i, data[i]])
	                    }
	                    return res;
	                }


	                /* Interactive Chart */
	                function chart2() {
	                    var pageviews = JSON.parse(document.getElementById('data').value);

	                    var med = JSON.parse(document.getElementById('meddata').value);

	                    var timeline = JSON.parse(document.getElementById('data5').value);
	              
	                    var surgery = JSON.parse(document.getElementById('dataSurgery').value);

	                    var episodes = JSON.parse(document.getElementById('dataepisode').value);

	                    var badness = JSON.parse(document.getElementById('databadness').value);


	                    var plot = $.plot($("#chart_2"), [{
	                        data: pageviews,
	                        label: "Seizures"
	                    }, {
	                        data: med,
	                        label: "Medecine"
	                    }, {
	                        data: surgery,
	                        label: "Surgery"
	                    }], {
	                        series: {
	                            lines: {
	                                show: true,
	                                lineWidth: 2,
	                                fill: true,
	                                fillColor: {
	                                    colors: [{
	                                        opacity: 0.05
	                                    }, {
	                                        opacity: 0.01
	                                    }
	                                    ]
	                                }
	                            },
	                            points: {
	                                show: true
	                            },
	                            shadowSize: 2
	                        },
	                        grid: {
	                            hoverable: true,
	                            clickable: true,
	                            tickColor: "#eee",
	                            borderWidth: 0
	                        },
	                        colors: ["#DB5E8C", "#F0AD4E", "#5E87B0"],
	                        xaxis: {
	                            ticks: timeline
	                        },
	                        yaxis: {
	                            ticks: 11,
	                            tickDecimals: 0
	                        }
	                    });


	                    function showTooltip(x, y, contents) {
	                        $('<div id="tooltip">' + contents + '</div>').css({
	                            position: 'absolute',
	                            display: 'none',
	                            top: y + 5,
	                            left: x + 15,
	                            border: '1px solid #333',
	                            padding: '4px',
	                            color: '#fff',
	                            'border-radius': '3px',
	                            'background-color': '#333',
	                            opacity: 0.80
	                        }).appendTo("body").fadeIn(200);
	                    }

	                    var previousPoint = null;
	                    $("#chart_2").bind("plothover", function (event, pos, item) {
	                        $("#x").text(pos.x.toFixed(2));
	                        $("#y").text(pos.y.toFixed(2));

	                        if (item) {
	                            if (previousPoint != item.dataIndex) {
                                
	                                previousPoint = item.dataIndex;
	                                //alert(item.series.label);
	                                $("#tooltip").remove();
	                                var x = item.datapoint[0].toFixed(2),
                                        y = item.datapoint[1].toFixed(2);

	                                switch(item.series.label) {
	                                    case "Seizures":
	                                        showTooltip(item.pageX, item.pageY, "Episode Badness: " + episodes[item.datapoint[0].toFixed(0)][1] + "\n Confidence: " + badness[item.datapoint[0].toFixed(0)][1]);
	                                        break;
	                                    case "Surgery":
	                                        showTooltip(item.pageX, item.pageY, item.series.label + " of " + x + " = " + y);
	                                        break;

	                                }
	                            }
	                        } else {
	                            $("#tooltip").remove();
	                            previousPoint = null;
	                        }
	                    });
	                }










	                //graph

	                chart2();

	            }




	        };

	    }();

    </script>
	<!-- /JAVASCRIPTS -->
</body>
</html>