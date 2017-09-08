var _imgNum = $('#count').val(),
	_currectNum = 0,
	_carouselBlock,
	_carouselContenter,
	_carouselControl,
	_carouselTimer,
	_carouseInterval = 5000,
	_carouselAnimateTime = 700,
	_carouselWidth = 800,
	_carouselIsAnimate = false;

$(function () {
	_carouselBlock = $('.myCarousel');
	_carouselContenter = _carouselBlock.find('.carousel_contenter');
	_carouselControl = _carouselBlock.find('.carousel_control');
	
	_carouselContenter.width(_carouselWidth * _imgNum).css({left:0});
	_carouselControl.find('li').eq(_currectNum).addClass('active');

	_carouselTimer = setTimeout(CarouslToNext, _carouseInterval);
	_carouselIsAnimate = false;

	$('li', _carouselControl).click(function () {
		CarouslTo($(this).index());
	});

	$('.carousel_previous', _carouselBlock).click(function () {
		CarouslTo(_currectNum - 1);
	});

	$('.carousel_next', _carouselBlock).click(function () {
		CarouslTo(_currectNum + 1);
	});

	function CarouslToNext() {
		CarouslTo(_currectNum + 1);
	}

	function CarouslTo(ind) {

		if (_carouselIsAnimate) {
			return false;
		}

		_carouselIsAnimate = true;
		clearTimeout(_carouselTimer);
		_carouselContenter.css({ left: -_currectNum * _carouselWidth + 'px' });

		if (ind < 0) {
			ind = _imgNum - 1;
		}
		else if (ind >= _imgNum) {
			ind = 0;
		}

		_currectNum = ind;

		_carouselContenter.animate({
			left: -_currectNum * _carouselWidth + 'px'
		},
		_carouselTimer,
		function () {
			_carouselControl.find('li.active').removeClass('active');
			_carouselControl.find('li').eq(_currectNum).addClass('active');

			_carouselIsAnimate = false;
			_carouselTimer = setTimeout(CarouslToNext, _carouseInterval);
		});
	}
});