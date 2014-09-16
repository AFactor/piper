class NavigationHelper

  extend TestUtils

  def self.create_super_department_url
    ApiConfig.navigation_url + ApiConfig.type_super_department
  end

  def self.create_department_url(taxonomy_id)
    ApiConfig.navigation_url + ApiConfig.type_department + taxonomy_id
  end

  def self.create_all_levels_url
    ApiConfig.navigation_url + ApiConfig.type_all
  end

  def self.get_all_levels
    response_json = RestClient.get(create_all_levels_url){|response, request, result| response }
    check_response_code(200,response_json)
    response_json
  end

  def self.get_all_super_departments
    response_json = RestClient.get(create_super_department_url){|response, request, result| response }
    check_response_code(200,response_json)
    response_json
  end

  def self.get_all_departments_for(taxonomy_id)
    response_json = RestClient.get(create_department_url(taxonomy_id)){|response, request, result| response }
    check_response_code(200,response_json)
    response_json
  end
end