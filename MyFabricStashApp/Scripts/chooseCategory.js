$(function () {
    $('#categoryDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Add Category',
        buttons: {
            'Save': function () {
                var createCategoryForm = $('#createCategoryForm');
                if (createCategoryForm.valid()) {
                    $.post(createCategoryForm.attr('action'), createCategoryForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            //Add the new category to the dropdown list and select it
                            $('#MainCategoryId').append(
                                $('<option></option>')
                                    .val(data.MainCategory.MainCategoryId)
                                    .html(data.MainCategory.Name)
                                    .prop('selected', true) //selects the new Category in the DropDownList
                            );
                            $('#categoryDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancel': function () {
                $(this).dialog('close');
            }
        }
    });
    $('#categoryAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#categoryDialog').html('')
            .load(createFormUrl, function () {
                jQuery.validator.unobtrusive.parse('#createCategoryForm');
                $('#categoryDialog').dialog('open');
            });

        return false;
    })
})