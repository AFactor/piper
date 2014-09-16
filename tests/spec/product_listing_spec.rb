RSpec.describe "Product listings" do

  before(:each) do
    json_hash = NavigationHelper.parse_response(NavigationHelper.get_all_levels)['children'][0]['children'][0]['children'][0]
    n = json_hash['n']
    ne = json_hash['ne']
    @product_list_response = ProductListingHelper.parse_response(ProductListingHelper.get_list_of_products(n, ne))
  end

  it "products should have a product id and title" do
    @product_list_response.each do |product|
      product['productId'].should_not be_nil
      product['title'].should_not be_empty
    end
  end

  it "products should have a total price and unit of measure " do
    @product_list_response.each do |product|
      product['totalSellingPrice']['amount'].should_not be_nil
      product['unitOfMeasure'].should_not be_nil
    end
  end

  it "products should have 540x540 and 225x225 images" do
    @product_list_response.each do |product|
      product['media']['images'].each do |image|
        (image['height'].include?('540') || image['height'].include?('225')).should == true
        (image['width'].include?('540') || image['width'].include?('225')).should == true
      end
    end
  end



end
