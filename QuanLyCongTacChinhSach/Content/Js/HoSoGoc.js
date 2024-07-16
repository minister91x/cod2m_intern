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
                    appendDataStandardTerm(null);
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
            htmlMore = htmlMore.replace(/{id}/g, value.id);
            htmlMore = htmlMore.replace(/{hoTen}/g, value.hoTen);
            htmlMore = htmlMore.replace(/{soHieuQN}/g, value.soHieuQN);
            htmlMore = htmlMore.replace(/{ngaySinh}/g, value.ngaySinh);
            htmlMore = htmlMore.replace(/{loaiHoSo}/g, value.loaiHoSo);
            htmlMore = htmlMore.replace(/{quyenSo}/g, value.quyenSo);
            htmlMore = htmlMore.replace(/{soThuTu}/g, value.soThuTu);
            htmlMore = htmlMore.replace(/{batDau}/g, value.batDau);
            htmlMore = htmlMore.replace(/{ketThuc}/g, value.ketThuc);
            htmlMore = htmlMore.replace(/{id_CoQuanTTBo}/g, value.id_CoQuanTTBo);
            htmlMore = htmlMore.replace(/{id_CoQuanTinh}/g, value.id_CoQuanTinh);
            htmlMore = htmlMore.replace(/{id_CoQuanHuyen}/g, value.id_CoQuanHuyen);
            htmlMore = htmlMore.replace(/{id_CoQuanXa}/g, value.id_CoQuanXa);
            htmlMore = htmlMore.replace(/{id_CoQuanCuThe}/g, value.id_CoQuanCuThe);
            htmlMore = htmlMore.replace(/{maHoSo}/g, value.maHoSo);
            $("#body-table-hosogoc").append(htmlMore);
        });
    }
}