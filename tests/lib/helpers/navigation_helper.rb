class NavigationHelper

  def self.create_super_department_url
    ConfigurationManager.load_config('config', ENV['ENVIRONMENT'])['navigation_base_url'] + ConfigurationManager.load_config('config', ENV['ENVIRONMENT'])['type_super_department']
  end

  def self.create_department_url(taxonomy_id)
    ConfigurationManager.load_config('config', ENV['ENVIRONMENT'])['navigation_base_url'] + ConfigurationManager.load_config('config', ENV['ENVIRONMENT'])['type_department']+taxonomy_id
  end

  def self.create_all_levels_url
    ConfigurationManager.load_config('config', ENV['ENVIRONMENT'])['navigation_base_url'] + ConfigurationManager.load_config('config', ENV['ENVIRONMENT'])['type_all']
  end

  def self.get_all_levels
    response_json = RestClient.get(create_all_levels_url){|response, request, result| response }
    response_json.code.should eql 200
    response_json
  end

  def self.get_all_super_departments
    response_json = RestClient.get(create_super_department_url){|response, request, result| response }
    response_json.code.should eql 200
    response_json
  end

  def self.get_all_departments_for(taxonomy_id)
    response_json = RestClient.get(create_department_url(taxonomy_id)){|response, request, result| response }
    response_json.code.should eql 200
    response_json
  end

  def self.parse_response(response)
    JSON.parse(response.body)
  end


end