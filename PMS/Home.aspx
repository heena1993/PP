<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PMSMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="banner_w3ls w3layouts">
        <script>
            // You can also use "$(window).load(function() {"
            $(function () {
                // Slideshow 4
                $("#slider3").responsiveSlides({
                    auto: true,
                    pager: true,
                    nav: true,
                    speed: 500,
                    namespace: "callbacks",
                    before: function () {
                        $('.events').append("<li>before event fired.</li>");
                    },
                    after: function () {
                        $('.events').append("<li>after event fired.</li>");
                    }
                });
            });
        </script>
        <div id="top" class="callbacks_container">
            <ul class="rslides" id="slider3">
                <li>
                    <div class="banner-info w3">
                        <div class="banner-text w3l">
                            <h3>WE CARE<span>ABOUT OUR PATIENTS</span></h3>
                            <p>
                                At vero eos et accusamus et iusto odio dignissimos 
							ducimus qui blanditiis praesentium voluptatum deleniti atque 
							corrupti quos dolores et quas molestias excepturi.
                            </p>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="banner-info w3ls">
                        <div class="banner-text agileits">
                            <h3>WE ARE FOCUSSED YOU<span>ROUND THE CLOCK</span></h3>
                            <p>
                                At vero eos et accusamus et iusto odio dignissimos 
							ducimus qui blanditiis praesentium voluptatum deleniti atque 
							corrupti quos dolores et quas molestias excepturi.
                            </p>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="banner-info agileinfo">
                        <div class="banner-text wthree">
                            <h3>HELPING YOU<span>LIVE YOUR HEALTHY LIFE</span></h3>
                            <p>
                                At vero eos et accusamus et iusto odio dignissimos 
							ducimus qui blanditiis praesentium voluptatum deleniti atque 
							corrupti quos dolores et quas molestias excepturi.
                            </p>
                        </div>
                    </div>
                </li>
            </ul>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>

