/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />

var CustomerView = Backbone.View.extend({
	model: Customer,
	events: {
		'dblclick #labeler': 'edit',
		'keyup #editor': 'update',
		'click #Delete':'delete'
	},
	tagName: 'li',
	edit: function () {
		this.$el.find('#labeler').toggleClass('hide');
		this.$el.find('#editor').toggleClass('hide');
		this.$el.find('#editor').toggleClass('show');
	},
	update: function (e) {		
		console.log($("div[class!='hide'] #TitleEdit").val());			
		if (e.which == 13) {
		console.log($(".show #TitleEdit").val());			
			this.close();
		}
		else if (e.which == 27) {
			this.edit();
		}

	},
	close: function () {		
		this.model.set("Title", $(".show #TitleEdit").val());
		this.model.set("FirstName", $(".show #FirstNameEdit").val());
		this.model.set("LastName", $(".show #LastNameEdit").val());
		console.log(JSON.stringify(this.model.toJSON()));
		this.model.save('', '', { success: function () { custCollection.fetch(); } });
	},	
	delete:function(){				
		this.model.url=this.model.url + this.model.get("Id");		
		this.model.destroy({success:function(){
		custCollection.fetch();
		}
		});
	},
	render: function () {
		this.$el.html(_.template(custTemplate, this.model.toJSON()));
		return this;
	}
});