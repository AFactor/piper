class ProductListingHelper

  extend TestUtils

  def self.create_product_listing_url(n,ne)
    ApiConfig.aisle_url.gsub('something', n).gsub('_else',ne)
  end

  def self.get_list_of_products(n,ne)
    response_json = RestClient.get(create_product_listing_url(n,ne)){|response, request, result| response }
    check_response_code(200,response_json)
    response_json
  end


end
