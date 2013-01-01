/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />
/// <reference path="../require-jquery.js" />

define(['jquery','backbone','underscore','CustomerCollection','CustTemplate','Customer','App'],
function($,Backbone,_,CustomerCollection,CustTemplate,Customer,App) {
    
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
			if (e.which == 13) {			
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
			this.model.save('', '', { success: function () { CustomerCollection.fetch(); } });
		},	
		delete:function(){				
			this.model.url=this.model.url + this.model.get("Id");		
			this.model.destroy({success:function(){
			CustomerCollection.fetch();
			}
			});
		},
		render: function () {
			this.$el.html(_.template(custTemplate, this.model.toJSON()));
			return this;
		}
	});
	return CustomerView;
});