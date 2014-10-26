<%@ Page Language="C#" AutoEventWireup="true" CodeFile="flot_charts.aspx.cs" Inherits="flot_charts" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta http-equiv="content-type" content="text/html; charset=UTF-8">
	<meta charset="utf-8">
	<title>Cloud Admin | Flot Charts</title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=no">
	<meta name="description" content="">
	<meta name="author" content="">
	<!-- STYLESHEETS --><!--[if lt IE 9]><script src="js/flot/excanvas.min.js"></script><script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script><script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script><![endif]-->
	<link rel="stylesheet" type="text/css" href="css/cloud-admin.css" >
	<link rel="stylesheet" type="text/css"  href="css/themes/default.css" id="skin-switcher" >
	<link rel="stylesheet" type="text/css"  href="css/responsive.css" >
	
	<link href="font-awesome/css/font-awesome.min.css" rel="stylesheet">
	<!-- DATE RANGE PICKER -->
	<link rel="stylesheet" type="text/css" href="js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
	<!-- FONTS -->
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700' rel='stylesheet' type='text/css'>
</head>
<body>
	<!-- HEADER -->
	<header class="navbar clearfix" id="header">
		<div class="container">
				<div class="navbar-brand">
					<!-- COMPANY LOGO -->
					<a href="index.html">
						<img src="img/logo/logo.png" alt="Cloud Admin Logo" class="img-responsive" height="30" width="120">
					</a>
					<!-- /COMPANY LOGO -->
					
					
				</div>
				
				
		</div>
		
		
	</header>
	<!--/HEADER -->
	
	<!-- PAGE -->
	<section id="page">
				
		<div id="main-content">
			<!-- SAMPLE BOX CONFIGURATION MODAL FORM-->
			<div class="modal fade" id="box-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
				  <div class="modal-content">
					<div class="modal-header">
					  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					  <h4 class="modal-title">Box Settings</h4>
					</div>
					<div class="modal-body">
					  Here goes box setting content.
					</div>
					<div class="modal-footer">
					  <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					  <button type="button" class="btn btn-primary">Save changes</button>
					</div>
				  </div>
				</div>
			  </div>
			<!-- /SAMPLE BOX CONFIGURATION MODAL FORM-->
			<div class="container">
				<div class="row">
					<div id="content" class="col-lg-12">
						<!-- PAGE HEADER-->
						<div class="row">
							<div class="col-sm-12">
								<div class="page-header">
									<!-- STYLER -->
									
									<!-- /STYLER -->
									<!-- BREADCRUMBS -->
									<ul class="breadcrumb">
										<li>
											<i class="fa fa-home"></i>
											<a href="index.html">Home</a>
										</li>
										<li>
											<a href="#">Visual Charts</a>
										</li>
										<li>Flot Charts</li>
									</ul>
									<!-- /BREADCRUMBS -->
									<div class="clearfix">
										<h3 class="content-title pull-left">Flot Charts</h3>
									</div>
									<div class="description">Beautiful Flot Line, Bar and Pie Charts</div>
								</div>
							</div>
						</div>
						<!-- /PAGE HEADER -->
						
						<div class="separator"></div>
						<!-- INTERACTIVE CHART -->
						<div class="row">
							<div class="col-md-12">
								<!-- BOX -->
								<div class="box border blue">
									<div class="box-title">
										<h4><i class="fa fa-signal"></i>Interactive Chart</h4>
										<div class="tools">
											<a href="#box-config" data-toggle="modal" class="config">
												<i class="fa fa-cog"></i>
											</a>
											<a href="javascript:;" class="reload">
												<i class="fa fa-refresh"></i>
											</a>
											<a href="javascript:;" class="collapse">
												<i class="fa fa-chevron-up"></i>
											</a>
											<a href="javascript:;" class="remove">
												<i class="fa fa-times"></i>
											</a>
										</div>
									</div>
									<div class="box-body">
										<div id="chart_2" class="chart"></div>
									</div>
								</div>
								<!-- /BOX -->
							</div>
						</div>
						<!-- /INTERACTIVE CHART -->
						<div class="separator"></div>
						
						
							</div>
						</div>
						
						<div class="footer-tools">
							<span class="go-top">
								<i class="fa fa-chevron-up"></i> Top
							</span>
						</div>
					</div><!-- /CONTENT-->
				</div>
			</div>
		</div>
	</section>
	<!--/PAGE -->
	<!-- JAVASCRIPTS -->
	<!-- Placed at the end of the document so the pages load faster -->
	<!-- JQUERY -->
	<script src="js/flot/jquery.min.js"></script>
	<!-- JQUERY UI-->
	<script src="js/jquery-ui-1.10.3.custom/js/jquery-ui-1.10.3.custom.min.js"></script>
	<!-- BOOTSTRAP -->
	<script src="bootstrap-dist/js/bootstrap.min.js"></script>
	
		
	<!-- DATE RANGE PICKER -->
	<script src="js/bootstrap-daterangepicker/moment.min.js"></script>
	
	<script src="js/bootstrap-daterangepicker/daterangepicker.min.js"></script>
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
		                var pageviews = [
                            [30, 10],
                            [29, 24],
                            [28, 38],
                            [27, 32],
                            [26, 31],
                            [25, 25],
                            [24, 35],
                            [23, 46],
                            [22, 36],
                            [21, 48],
                            [20, 38],
                            [19, 60],
                            [18, 63],
                            [17, 72],
                            [16, 58],
                            [15, 65],
                            [14, 50],
                            [13, 32],
                            [12, 40],
                            [11, 35],
                            [10, 30],
                            [9, 35],
                            [8, 50],
                            [7, 53],
                            [6, 42],
                            [5, 34],
                            [4, 22],
                            [3, 15],
                            [2, 20],
                            [1, 5]
		                ];
		                var visitors = [
                            [1, 0],
                            [2, 14],
                            [3, 28],
                            [4, 22],
                            [5, 21],
                            [6, 15],
                            [7, 25],
                            [8, 36],
                            [9, 26],
                            [10, 38],
                            [11, 28],
                            [12, 50],
                            [13, 53],
                            [14, 62],
                            [15, 48],
                            [16, 55],
                            [17, 40],
                            [18, 22],
                            [19, 30],
                            [20, 25],
                            [21, 20],
                            [22, 15],
                            [23, 40],
                            [24, 43],
                            [25, 32],
                            [26, 24],
                            [27, 12],
                            [28, 5],
                            [29, 19],
                            [30, 27]
		                ];

		                var plot = $.plot($("#chart_2"), [{
		                    data: pageviews,
		                    label: "Unique Visits"
		                }, {
		                    data: visitors,
		                    label: "Page Views"
		                }
		                ], {
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
		                        ticks: 11,
		                        tickDecimals: 0
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

		                            $("#tooltip").remove();
		                            var x = item.datapoint[0].toFixed(2),
                                        y = item.datapoint[1].toFixed(2);

		                            showTooltip(item.pageX, item.pageY, item.series.label + " of " + x + " = " + y);
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