<script type="text/javascript">
        $(document).ready(function () {
            // jquery Progress bar function.   
            $("#progressbar").progressbar({ value: 0 });
            $("#lbldisp").hide();
            $("#progressbar").hide();
            //button click event   
            $("#btnGetData").click(function () {
                $("#btnGetData").attr("disabled", "disabled")
                $("#lbldisp").show();
                $("#progressbar").show();
                //call back function   
                var intervalID = setInterval(updateProgress, 250);
                $.ajax({
                    type: "POST",
                    url: "ProgressBar.aspx/GetText",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (msg) {
                        $("#progressbar").progressbar("value", 100);
                        $("#lblStatus").hide();
                        $("#lbldisp").text(msg.d);
                        clearInterval(intervalID);
                    }
                });
                return false;
            });
        });

        function updateProgress() {
            var value = $("#progressbar").progressbar("option", "value");
            if (value < 100) {
                $("#progressbar").progressbar("value", value + 1);
                $("#lblStatus").text((value + 1).toString() + "%");
            }
        }
    </script>