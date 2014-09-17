module TestUtils

  def parse_response(response)
    JSON.parse(response.body)
  end

  def check_response_code(code,response)
    response.code.should eql code.to_i
  end


end