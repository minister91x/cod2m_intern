function showHoSoGoc(page) {
    if (flag == false) {
        flag = true;
        let formData = $('#Form_HoSoGoc').serialize();
        formData += '&Page=' + page;
        $.ajax({
            type: "GET",
            url: "/HoSoGoc/Search",
            data: formData,
            success: function (result) {
                flag = false;
                if (result.data.length > 0) {
                    appendSearchHoSoGoc(result.data);
                    totalPages = result.totalRecords;
                    currentPage = result.pageNumber;
                    pageSize = result.pageSize;
                }
                else {
                    appendSearchHoSoGoc(null);
                }
            }
        });
    }
}
function appendSearchHoSoGoc(items) {
    $("#body-table-hosogoc").html("");
    if (items != null) {
        $.each(items, (index, value) => {
            let htmlMore = $('#templateHtmlShowHoSoGoc').html();
            htmlMore = htmlMore.replace(/{Id_ThongTin}/g, value.Id_ThongTin);
            htmlMore = htmlMore.replace(/{HoTen}/g, value.HoTen);
            htmlMore = htmlMore.replace(/{MaNV}/g, value.MaNV);
            htmlMore = htmlMore.replace(/{MaHoSo}/g, value.MaHoSo);
            htmlMore = htmlMore.replace(/{LoaiHoSo}/g, value.LoaiHoSo);
            htmlMore = htmlMore.replace(/{NgaySinh}/g, value.NgaySinh);
            htmlMore = htmlMore.replace(/{BatDau}/g, value.BatDau);
            htmlMore = htmlMore.replace(/{KetThuc}/g, value.KetThuc);
            htmlMore = htmlMore.replace(/{Id_CoQuanTTBo}/g, value.Id_CoQuanTTBo);
            htmlMore = htmlMore.replace(/{Id_CoQuanTinh}/g, value.Id_CoQuanTinh);
            htmlMore = htmlMore.replace(/{Id_CoQuanHuyen}/g, value.Id_CoQuanHuyen);
            htmlMore = htmlMore.replace(/{Id_CoQuanCuThe}/g, value.Id_CoQuanCuThe);
            $("#body-table-hosogoc").append(htmlMore);
        });
    }
}
function populateForm(data) {
    if (data != null) {
        // Iterate over the data object
        for (const key in data) {
            if (data.hasOwnProperty(key)) {
                const element = document.getElementById(key);
                if (element) {
                    element.value = data[key];
                }
            }
        }
    }
}