$(document).ready(function () {
    $('#paginas').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Motrando _START_ registro de _END_ em um total de _TOTAL_ entradas",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Preparando...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "Nada encontrado",
            "paginate": {
                "first": "Primeiro",
                "last": "Ultimo",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        }
    });
});
