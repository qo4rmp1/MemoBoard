$(function () {
	$(document).delegate('#CreateArticleModal #createBtn', 'click', function () {
		$('#CreateArticleModal form').submit();
	});
});

function onArticleModalCreateSuccess() {
	$('#CreateArticleModal').modal('hide');
	$('#Search').val(null);
	$('#RefreshListLink').click();
}